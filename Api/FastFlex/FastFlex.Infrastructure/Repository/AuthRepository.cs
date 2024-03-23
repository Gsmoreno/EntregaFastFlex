using FastFlex.Infrastructure.Interfaces;
using FastFlex.Models.Context;
using FastFlex.Models.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static FastFlex.Infrastructure.Helpers.Enum;

namespace FastFlex.Infrastructure.Repository
{
    public class AuthRepository : IAuthRepository
    {
        FastFlexContext _ctx = new FastFlexContext();

        private readonly IConfiguration _configuration;

        public AuthRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<string> Login(string email, string password)
        {
            try
            {
                var dbSearch = _ctx.Usuarios.Where(x => x.Email == email && x.Senha == password).FirstOrDefault();

                if (dbSearch == null)
                {
                    return Task.FromResult(string.Empty);
                }

                var token = CreateToken(dbSearch);

                return Task.FromResult(token);
            }
            catch (Exception ex)
            {
                return Task.FromResult(ex.ToString());   
            }
        }

        private string CreateToken(UsuarioDto usuario)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:TokenKey").Value);

            var tipoUsuario = "";

            if (usuario.TipoUsuarioId == (int)TipoUsuario.Admin)
            {
                tipoUsuario = TipoUsuario.Admin.ToString();
            }
            else if(usuario.TipoUsuarioId == (int)TipoUsuario.Cliente)
            {
                tipoUsuario = TipoUsuario.Cliente.ToString();
            }
            else if (usuario.TipoUsuarioId == (int)TipoUsuario.Entregador)
            {
                tipoUsuario = TipoUsuario.Entregador.ToString();
            }
            else
            {
                tipoUsuario = TipoUsuario.Base.ToString();
            }

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.Role, tipoUsuario)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                IssuedAt = DateTime.UtcNow,    
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(securityTokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private void CreatePasswordHash(string password)
        {
           SHA256 hash = SHA256.Create();

            var passwordBytes = Encoding.Default.GetBytes(password);
        }
    }
}
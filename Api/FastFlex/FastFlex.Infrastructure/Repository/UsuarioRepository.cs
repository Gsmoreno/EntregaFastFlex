using FastFlex.Infrastructure.Interfaces;
using FastFlex.Models.Context;
using FastFlex.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFlex.Infrastructure.Repository
{
    public class UsuarioRepository : GenericsRepository<UsuarioDto>, IUsuarioRepository
    {
        private readonly DbContextOptions<FastFlexContext> _OptionBuilder;

        FastFlexContext _ctx = new FastFlexContext();

        public UsuarioRepository()
        {
            _OptionBuilder = new DbContextOptions<FastFlexContext>();
        }

        public int GetUserId(string email, string password)
        {
            var dbSearch = _ctx.Usuarios.Where(x => x.Email == email && x.Senha == password).FirstOrDefault();

            if (dbSearch == null)
            {
                return 0;
            }
            
            return dbSearch.UserId;
        }
    }
}
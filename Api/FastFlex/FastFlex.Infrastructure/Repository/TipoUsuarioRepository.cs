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
    public class TipoUsuarioRepository : GenericsRepository<TipoUsuarioDto>, ITipoUsuarioRepository
    {
        private readonly DbContextOptions<FastFlexContext> _OptionBuilder;

        public TipoUsuarioRepository()
        {
            _OptionBuilder = new DbContextOptions<FastFlexContext>();   
        }
    }
}
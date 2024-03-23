using FastFlex.Infrastructure.Interfaces;
using FastFlex.Models.Context;
using FastFlex.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFlex.Infrastructure.Repository
{
    public class EntregadorRepository : GenericsRepository<EntregadorDto>, IEntregadorRepository
    {
        private readonly DbContextOptions<FastFlexContext> _OptionsBuilder;

        public EntregadorRepository()
        {
            _OptionsBuilder = new DbContextOptions<FastFlexContext>();
        }
    }
}
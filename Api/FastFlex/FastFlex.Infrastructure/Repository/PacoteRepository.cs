using FastFlex.Infrastructure.Interfaces;
using FastFlex.Models.Context;
using FastFlex.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFlex.Infrastructure.Repository
{
    public class PacoteRepository : GenericsRepository<PacoteDto>, IPacoteRepository
    {
        private readonly DbContextOptions<FastFlexContext> _OptionBuilder;

        public PacoteRepository()
        {
            _OptionBuilder = new DbContextOptions<FastFlexContext>();   
        }
    }
}
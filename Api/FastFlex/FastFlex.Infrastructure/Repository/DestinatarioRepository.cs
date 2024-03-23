using FastFlex.Infrastructure.Interfaces;
using FastFlex.Models.Context;
using FastFlex.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFlex.Infrastructure.Repository
{
    public class DestinatarioRepository : GenericsRepository<DestinatarioDto>, IDestinatarioRepository
    {
        private readonly DbContextOptions<FastFlexContext> _OptionsBuilder;

        FastFlexContext _ctx = new FastFlexContext();

        public DestinatarioRepository()
        {
            _OptionsBuilder = new DbContextOptions<FastFlexContext>();
        }

        public async Task<int> AdicionaDestinatario(DestinatarioDto destinatario)
        {
            _ctx.Add(destinatario);

            _ctx.SaveChanges();

            return destinatario.DestinatarioId;
        }
    }
}
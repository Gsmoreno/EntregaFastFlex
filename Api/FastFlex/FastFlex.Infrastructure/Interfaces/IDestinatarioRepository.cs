using FastFlex.Models.Models;

namespace FastFlex.Infrastructure.Interfaces
{
    public interface IDestinatarioRepository : IGenericRepository<DestinatarioDto>
    {
        public Task<int> AdicionaDestinatario(DestinatarioDto destinatario);
    }
}
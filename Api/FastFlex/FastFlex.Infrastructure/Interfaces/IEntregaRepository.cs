using FastFlex.Models.Models;

namespace FastFlex.Infrastructure.Interfaces
{
    public interface IEntregaRepository : IGenericRepository<EntregaDto>
    {
        public Task<int> AdicionaEntrega(EntregaDto entregaDto);
    }
}
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
    public class EntregaRepository : GenericsRepository<EntregaDto>, IEntregaRepository
    {
        private readonly DbContextOptions<FastFlexContext> _OptionsBuilder;

        FastFlexContext _ctx = new FastFlexContext();


        public EntregaRepository()
        {
            _OptionsBuilder = new DbContextOptions<FastFlexContext>();
        }

        public async Task<int> AdicionaEntrega(EntregaDto entregaDto)
        {
            _ctx.Add(entregaDto);

            _ctx.SaveChanges();

            return entregaDto.EntregaId;
        }
    }
}
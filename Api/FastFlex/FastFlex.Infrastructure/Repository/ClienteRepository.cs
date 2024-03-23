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
    public class ClienteRepository : GenericsRepository<ClienteDto>, IClienteRepository
    {
        private readonly DbContextOptions<FastFlexContext> _OptionBuilder;

        public ClienteRepository()
        {
            _OptionBuilder = new DbContextOptions<FastFlexContext>(); 
        }
    }
}
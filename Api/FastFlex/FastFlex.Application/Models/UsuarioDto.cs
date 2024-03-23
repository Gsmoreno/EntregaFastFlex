using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FastFlex.Models.Models
{
    public partial class UsuarioDto
    {
        public UsuarioDto()
        {
            Clientes = new HashSet<ClienteDto>();
            Entregadors = new HashSet<EntregadorDto>();
        }

        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public bool Ativado { get; set; } 
        public int? TipoUsuarioId { get; set; }

        [JsonIgnore]
        public virtual TipoUsuarioDto? TipoUsuario { get; set; }
        [JsonIgnore]
        public virtual ICollection<ClienteDto> Clientes { get; set; }
        [JsonIgnore]
        public virtual ICollection<EntregadorDto> Entregadors { get; set; }
    }
}
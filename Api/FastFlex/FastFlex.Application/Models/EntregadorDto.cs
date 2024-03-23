using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FastFlex.Models.Models
{
    public partial class EntregadorDto
    {
        public EntregadorDto()
        {
            Entregas = new HashSet<EntregaDto>();
        }

        public int EntregadorId { get; set; }
        public string Nome { get; set; } = null!;
        public string? Sobrenome { get; set; }
        public string NumeroDocumento { get; set; } = null!;
        public string Mei { get; set; } = null!;
        public string Endereco { get; set; } = null!;
        public int Numero { get; set; }
        public string Bairro { get; set; } = null!;
        public string Cidade { get; set; } = null!;
        public string Cep { get; set; } = null!;    
        public string Uf { get; set; } = null!;
        public int? UserId { get; set; }

        [JsonIgnore]
        public virtual UsuarioDto? User { get; set; }

        [JsonIgnore]
        public virtual ICollection<EntregaDto> Entregas { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FastFlex.Models.Models
{
    public partial class ClienteDto
    {
        public ClienteDto()
        {
            Entregas = new HashSet<EntregaDto>();
        }

        public int ClienteId { get; set; }
        public string NomeFantasia { get; set; } = null!;
        public string RazaoSocial { get; set; } = null!;
        public string Contato { get; set; } = null!;
        public int Telefone { get; set; }
        public string Email { get; set; } = null!;
        public string Logradouro { get; set; } = null!;
        public string Bairro { get; set; } = null!;
        public string Cep { get; set; }
        public string Cidade { get; set; } = null!;
        public string Uf { get; set; } = null!;
        public string Cpnj { get; set; } = null!;
        public int Numero { get; set; }
        public bool Ativado { get; set; } = false;
        public string Descricao { get; set; }
        public int? UserId { get; set; }

        [JsonIgnore]
        public virtual UsuarioDto? User { get; set; }
        [JsonIgnore]
        public virtual ICollection<EntregaDto> Entregas { get; set; }
    }
}
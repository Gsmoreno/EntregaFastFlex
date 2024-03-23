using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FastFlex.Models.Models
{
    public partial class EntregaDto
    {
        public EntregaDto()
        {
            Pacotes = new HashSet<PacoteDto>();
        }

        public int EntregaId { get; set; }
        public string CepDestino { get; set; } = null!;
        public string CepOrigem { get; set; } = null!;
        public string Rua { get; set; } = null!;
        public int Numero { get; set; }
        public string Bairro { get; set; } = null!;
        public decimal PrecoEntrega { get; set; }
        public int QtdPacotes { get; set; }
        public DateTime HoraSaida { get; set; }
        public DateTime HoraEntrega { get; set; }
        public string Status { get; set; }
        public int? EntregadorId { get; set; }
        public int? ClienteId { get; set; }
        public int? DestinatarioId { get; set; }

        [JsonIgnore]
        public virtual ClienteDto? Cliente { get; set; }
        [JsonIgnore]
        public virtual DestinatarioDto? Destinatario { get; set; }
        [JsonIgnore]
        public virtual EntregadorDto? Entregador { get; set; }
        [JsonIgnore]
        public virtual ICollection<PacoteDto> Pacotes { get; set; }
    }
}

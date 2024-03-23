using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FastFlex.Models.Models
{
    public partial class PacoteDto
    {
        public PacoteDto()
        {

        }

        public int PacoteId { get; set; }
        public decimal? Altura { get; set; }
        public decimal? Largura { get; set; }
        public decimal? Comprimento { get; set; }
        public decimal? Peso { get; set; }
        public int? EntregaId { get; set; }
        public decimal? ValorDeclarado { get; set; }

        [JsonIgnore]
        public virtual EntregaDto? Entrega { get; set; }
    }
}
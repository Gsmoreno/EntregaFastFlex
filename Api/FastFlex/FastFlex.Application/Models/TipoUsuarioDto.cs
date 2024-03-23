using System;
using System.Collections.Generic;

namespace FastFlex.Models.Models
{
    public partial class TipoUsuarioDto
    {
        public TipoUsuarioDto()
        {
            Usuarios = new HashSet<UsuarioDto>();
        }

        public int TipoUsuarioId { get; set; }
        public string? Nome { get; set; }

        public virtual ICollection<UsuarioDto> Usuarios { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_gufi_webAPI.Domains
{
    public partial class TiposEvento
    {
        public TiposEvento()
        {
            // HashSet quer dizer que não é uma lista ordenada
            Eventos = new HashSet<Evento>();
        }

        public int IdTipoEvento { get; set; }

        [Required(ErrorMessage = "Campo 'TituloTipoEvento' obrigatório!")]
        public string TituloTipoEvento { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; }
    }
}

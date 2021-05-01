using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_gufi_webAPI.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Presencas = new HashSet<Presenca>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Campo 'Email' obrigatório!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo 'Senha' obrigatório!")]
        public string Senha { get; set; }

        public virtual TiposUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Presenca> Presencas { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webAPI.ViewModels
{
    /// <summary>
    /// Modelo específico que será utilizado, nesse caso, para criar um Login.
    /// É utilizado apenas uma parte de uma Domain, só para transferência de dados.
    /// Não é uma Domain, pois não representa uma tabela no BD.
    /// </summary>
    public class LoginViewModel
    {
        // define que a propriedade é obrigatória
        [Required(ErrorMessage = "Informe o e-mail do usuário!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário!")]
        public string Senha { get; set; }
    }
}

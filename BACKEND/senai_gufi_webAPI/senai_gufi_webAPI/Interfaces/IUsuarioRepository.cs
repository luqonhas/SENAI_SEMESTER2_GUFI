using senai_gufi_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webAPI.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// valida o usuário
        /// </summary>
        /// <param name="email"> email do usuário </param>
        /// <param name="senha"> senha do usuário </param>
        /// <returns> retorna um token do usuário </returns>
        Usuario Login(string email, string senha);
    }
}

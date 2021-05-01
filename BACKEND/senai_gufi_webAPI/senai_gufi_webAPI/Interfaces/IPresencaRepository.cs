using senai_gufi_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webAPI.Interfaces
{
    interface IPresencaRepository
    {
        /// <summary>
        /// lista todos os eventos que um determinado usuário participa
        /// </summary>
        /// <param name="id"> ID do usuário que participa dos eventos listados </param>
        /// <returns> retorna uma lista de presencas com os dados dos eventos </returns>
        List<Presenca> ListarMinhasPresencas(int id);

        /// <summary>
        /// cria uma nova presenca
        /// </summary>
        /// <param name="inscricao"> objeto com as informações da inscrição </param>
        void Inscrever(Presenca inscricao);

        /// <summary>
        /// altera o status de uma presença
        /// </summary>
        /// <param name="id"> ID da presença que terá sua situação alterada </param>
        /// <param name="status"> parâmetro que atualiza a situação da presença, exemplo, 0 - RECUSADA, 1 - CONFIRMADO,  2 - NÃO CONFIRMADA </param>
        void AprovarRecusar(int id, string status);
    }
}

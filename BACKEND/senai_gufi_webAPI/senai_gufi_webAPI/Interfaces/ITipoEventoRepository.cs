using senai_gufi_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webAPI.Interfaces
{
    interface ITipoEventoRepository
    {
        // ESTRUTURA DE UM MÉTODO:

        // TipoRetorno NomeMetodo(TipoParametro NomeParametro)


        /// <summary>
        /// lista de todos os tipos de eventos
        /// </summary>
        /// <returns> retorna uma lista de TiposEvento </returns>
        List<TiposEvento> Listar();

        /// <summary>
        /// busca um tipo de evento através do id
        /// </summary>
        /// <param name="id"> id do tipo de evento que será buscado </param>
        /// <returns> retorna um tipo de evento que foi encontrado pelo id </returns>
        TiposEvento BuscarPorId(int id);

        /// <summary>
        /// cadastra um novo tipo de evento
        /// </summary>
        /// <param name="novoTipoEvento"> é o objeto que irá conter as informações que serão cadastradas </param>
        void Cadastrar(TiposEvento novoTipoEvento);

        /// <summary>
        /// atualiza um tipo de evento existente
        /// </summary>
        /// <param name="id"> id do tipo de evento que será atualizado </param>
        /// <param name="tipoAtualizado"> é o objeto que irá conter as novas informações </param>
        void Atualizar(int id, TiposEvento tipoAtualizado);

        /// <summary>
        /// deleta um tipo de evento existente
        /// </summary>
        /// <param name="id"> id do tipo de evento que será apagado </param>
        void Deletar(int id);
    }
}

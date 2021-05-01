using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_gufi_webAPI.Domains;
using senai_gufi_webAPI.Interfaces;
using senai_gufi_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PresencasController : ControllerBase
    {
        private IPresencaRepository _presencasRepository { get; set; }

        public PresencasController()
        {
            _presencasRepository = new PresencaRepository();
        }

        [HttpGet("minhas")]
        public IActionResult GetMy()
        {
            try
            {
                // se for para uma Claim personalizada
                // int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == "ClaimPersonalizada").Value);

                // cria uma variável "idUsuario" que recebe o valor do ID do usuário que está logado
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                // aparece o id do nosso usuário
                // return Ok(idUsuario);

                // retorna a resposta da requisição 200 - Ok, que faz a chamada para o método e trazendo a lista
                return Ok(_presencasRepository.ListarMinhasPresencas(idUsuario));
            }
            catch (Exception codErro)
            {

                return BadRequest(new 
                {
                    mensagem = "Não é possível mostrar as presenças se o usuário não estiver logado!",
                    codErro
                });
            }
        }

        /// <summary>
        /// inscreve o usuário logado em um evento
        /// </summary>
        /// <param name="idEvento"> ID do evento que o usuário irá se inscrever </param>
        /// <returns> retorna um statuscode 201 - created </returns>
        [HttpPost("inscricao/{idEvento}")]
        public IActionResult Join(int idEvento)
        {
            try
            {
                Presenca inscricao = new Presenca
                {
                    // armazena na propriedade IdUsuario a presença criada(inscricao) o ID do usuario logado
                    IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value),

                    // armazena na propriedade IdEvento o ID do evento recebido pela URL
                    IdEvento = idEvento,

                    // define a situação da presença como "Não confirmada"
                    Situacao = "Não confirmada"
                };

                // faz a chamada para o método
                _presencasRepository.Inscrever(inscricao);

                return StatusCode(201);
            }
            catch (Exception codErro)
            {

                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as presenças se o usuário não estiver logado!",
                    codErro
                });
            }
        }

        [Authorize(Roles = "1")]
        [HttpPatch("{id}")]
        public IActionResult UpdateSituation(int id, Presenca status)
        {
            try
            {
                _presencasRepository.AprovarRecusar(id, status.Situacao);

                return StatusCode(204);
            }
            catch (Exception codErro)
            {

                return BadRequest(new
                {
                    mensagem = "Não é possível atualizar presenças se não estiver logado!",
                    codErro
                });
            }
        }


    }
}

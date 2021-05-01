using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_gufi_webAPI.Domains;
using senai_gufi_webAPI.Interfaces;
using senai_gufi_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEventosController : ControllerBase
    {
        private ITipoEventoRepository _tipoEventoRepository { get; set; }

        public TipoEventosController()
        {
            _tipoEventoRepository = new TipoEventoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_tipoEventoRepository.Listar());
            }
            catch (Exception codErro)
            {
                // caso dê errado, retorna um erro 400 - BadRequest, com o código da exception
                return BadRequest(codErro);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_tipoEventoRepository.BuscarPorId(id));
            }
            catch (Exception codErro)
            {
                // caso dê errado, retorna um erro 400 - BadRequest, com o código da exception
                return BadRequest(codErro);
            }
        }

        [HttpPost]
        public IActionResult Post(TiposEvento novoTipo)
        {
            try
            {
                _tipoEventoRepository.Cadastrar(novoTipo);

                // StatusCode 201 - Created
                return StatusCode(201);
            }
            catch (Exception codErro)
            {
                // caso dê errado, retorna um erro 400 - BadRequest, com o código da exception
                return BadRequest(codErro);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TiposEvento tipoAtualizado)
        {
            try
            {
                _tipoEventoRepository.Atualizar(id, tipoAtualizado);

                // StatusCode 204 - No Content
                return StatusCode(204);
            }
            catch (Exception codErro)
            {
                // caso dê errado, retorna um erro 400 - BadRequest, com o código da exception
                return BadRequest(codErro);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tipoEventoRepository.Deletar(id);

            // StatusCode 204 - No Content
            return StatusCode(204);
        }

    }
}

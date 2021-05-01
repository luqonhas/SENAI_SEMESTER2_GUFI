using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_gufi_webAPI.Domains;
using senai_gufi_webAPI.Interfaces;
using senai_gufi_webAPI.Repositories;
using senai_gufi_webAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_gufi_webAPI.Controllers
{
    /// <summary>
    /// controller responsável pelos endpoints referentes ao Login
    /// </summary>

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// valida o usuário
        /// </summary>
        /// <param name="login"> objeto que contém o email e senha do usuário </param>
        /// <returns> retorna um token com as informações do usuário </returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                // busca o usuário pelo email e senha
                Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

                // se os dados estiverem errados...
                if (usuarioBuscado == null)
                {
                    return NotFound("E-mail ou senha inválidos!");
                }

                // se os dados estiverem certos e serem encontrados, prossegue para o token

                /*
                DEPENDÊNCIAS DO JWT (Pacotes):

                Criar e validar o JWT:      System.IdentityModel.Tokens.Jwt
                Integrar a autenticação:    Microsoft.AspNetCore.Authentication.JwtBearer (versão compatível com o .NET SDK do projeto)
                */

                // define os dados que serão fornecidos no token - o PAYLOAD
                var claims = new[]
                {
                    // armazena na Claim, o email do usuário, aquele que foi buscado
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),

                    // armazena na Claim, o ID do usuário autenticado
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),

                    // armazena na Claim, o tipo de usuário que foi autenticado ("Administrador")
                    // aqui a Role é o título da permissão
                    // new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuarioNavigation.TituloTipoUsuario)

                    // Armazena na Claim, o tipo de usuário que foi autenticado ("1")
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString())
                };

                // define a chave secreta ao token
                var secretKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("gufi-chave-autenticacao"));

                // define as credenciais do token, a sua assinatura
                var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var dadosToken = new JwtSecurityToken(
                    issuer:                 "gufi.webAPI",                  // emissor do token
                    audience:               "gufi.webAPI",                  // destinatário do token
                    claims:                 claims,                         // dados definidos acima
                    expires:                DateTime.Now.AddMinutes(30),    // tempo de expiração
                    signingCredentials:     credentials                     // credenciais do token
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(dadosToken)
                });

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

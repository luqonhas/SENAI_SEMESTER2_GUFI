using Microsoft.EntityFrameworkCore;
using senai_gufi_webAPI.Contexts;
using senai_gufi_webAPI.Domains;
using senai_gufi_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webAPI.Repositories
{
    public class PresencaRepository : IPresencaRepository
    {
        GufiContext ctx = new GufiContext();

        public void AprovarRecusar(int id, string status)
        {
            Presenca presencaBuscada = ctx.Presencas
                .Include(p => p.IdUsuarioNavigation)
                .Include(p => p.IdEventoNavigation)
                .FirstOrDefault(p => p.IdPresenca == id);

            switch (status)
            {
                case "0":
                    presencaBuscada.Situacao = "Recusada";
                    break;

                case "1":
                    presencaBuscada.Situacao = "Confirmada";
                    break;

                case "2":
                    presencaBuscada.Situacao = "Não confirmada";
                    break;

                default:
                    presencaBuscada.Situacao = presencaBuscada.Situacao;
                    break;
            }

            ctx.Presencas.Update(presencaBuscada);

            ctx.SaveChanges();
        }

        public void Inscrever(Presenca inscricao)
        {
            // Outra forma, caso os dados da inscrição (nova presença) sejam enviados pelo usuário independentemente do status que o usuário tente cadastrar ao se inscrever, por padrão, a situação será sempre "Não confirmada"
            // inscricao.Situacao = "Não confirmada!";

            // adiciona uma nova presença
            ctx.Presencas.Add(inscricao);

            // salva as informações no banco de dados
            ctx.SaveChanges();
        }

        public List<Presenca> ListarMinhasPresencas(int id)
        {
            // retorna uma lista com as informações das presenças
            return ctx.Presencas
                // adiciona na busca as informações dos eventos que o usuário participa
                .Include(x => x.IdEventoNavigation)
                // adiciona na busca as informações dos tipos de evento que o usuário participa
                .Include(x => x.IdEventoNavigation.IdInstituicaoNavigation)
                // adiciona na busca as informações das instituições onde os eventos acontecem
                .Include(x => x.IdEventoNavigation.IdInstituicaoNavigation)
                // estabelece como parâmetro de consulta o ID do usuário recebido
                .Where(x => x.IdUsuario == id)
                .ToList();
        }


    }
}

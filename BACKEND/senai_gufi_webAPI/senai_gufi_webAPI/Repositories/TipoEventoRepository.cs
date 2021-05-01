using senai_gufi_webAPI.Contexts;
using senai_gufi_webAPI.Domains;
using senai_gufi_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webAPI.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        GufiContext _context = new GufiContext();

        public void Atualizar(int id, TiposEvento tipoAtualizado)
        {
            TiposEvento tipoBuscado = BuscarPorId(id);

            if (tipoAtualizado.TituloTipoEvento != null)
            {
                tipoBuscado.TituloTipoEvento = tipoAtualizado.TituloTipoEvento;
            }

            _context.TiposEventos.Update(tipoBuscado);

            _context.SaveChanges();
        }

        public TiposEvento BuscarPorId(int id)
        {
            return _context.TiposEventos.FirstOrDefault(x => x.IdTipoEvento == id);
        }

        public void Cadastrar(TiposEvento novoTipoEvento)
        {
            _context.TiposEventos.Add(novoTipoEvento);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            // TiposEvento tipoBuscado = _context.TiposEventos.Find(id);

            _context.TiposEventos.Remove(BuscarPorId(id));

            _context.SaveChanges();
        }

        public List<TiposEvento> Listar()
        {
            return _context.TiposEventos.ToList();
        }
    }
}

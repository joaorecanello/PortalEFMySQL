using System;
using System.Collections.Generic;
using System.Linq;
using Portal.Dominio;
using Portal.Dominio.Contrato;

namespace Portal.Repositorio
{
    public class PalestranteAplicacaoEF : IRepositorio<Palestrante>
    {
        private readonly ContextoPortal _contexto;

        public PalestranteAplicacaoEF()
        {
            _contexto = new ContextoPortal();
        }
        public void Salvar(Palestrante entidade)
        {
            if (entidade.PalestranteId > 0)
            {
                var alterar = _contexto.Palestrantes.First(x => x.PalestranteId == entidade.PalestranteId);
                alterar.Tema = entidade.Tema;
                alterar.Instituicao = entidade.Instituicao;
                alterar.Horario = entidade.Horario;
                alterar.Dia = entidade.Dia;
                alterar.Horario = entidade.Horario;
            }
            else
            {

                _contexto.Palestrantes.Add(entidade);
            }
            _contexto.SaveChanges();
        }

        public void Excluir(Palestrante entidade)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Palestrante> ListarTodos()
        {
            return _contexto.Palestrantes;
        }

        public Palestrante ListarPorId(int id)
        {
            return _contexto.Palestrantes.First(x => x.PalestranteId == id);
        }
    }
}

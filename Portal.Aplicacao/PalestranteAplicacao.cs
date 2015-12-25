using System.Collections.Generic;
using Portal.Dominio;
using Portal.Dominio.Contrato;

namespace Portal.Aplicacao
{
    public class PalestranteAplicacao
    {
        private readonly IRepositorio<Palestrante> _contexto;

        public PalestranteAplicacao(IRepositorio<Palestrante> repositorio )
        {
            _contexto = repositorio;

        }

        
        public void Salvar(Palestrante palestrante)
        {
            _contexto.Salvar(palestrante);
            
        }

        public void Excluir(Palestrante palestrante)
        {
            _contexto.Excluir(palestrante);
            
        }

        public IEnumerable<Palestrante> ListarTodos()
        {
            return _contexto.ListarTodos();

        }

        public Palestrante ListarPorId(int id)
        {
            return _contexto.ListarPorId(id);
        }
    }
}

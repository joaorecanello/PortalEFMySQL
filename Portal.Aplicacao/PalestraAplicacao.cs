using System.Collections.Generic;
using Portal.Dominio;
using Portal.Dominio.Contrato;

namespace Portal.Aplicacao
{
    public class PalestraAplicacao
    {
        private readonly IRepositorio<Palestra> _contexto;

        public PalestraAplicacao(IRepositorio<Palestra> repositorio )
        {
            _contexto = repositorio;

        }

        
        public void Salvar(Palestra palestra)
        {
            _contexto.Salvar(palestra);
            
        }

        public void Excluir(Palestra palestra)
        {
            _contexto.Excluir(palestra);
            
        }

        public IEnumerable<Palestra> ListarTodos()
        {
            return _contexto.ListarTodos();

        }

        public Palestra ListarPorId(int id)
        {
            return _contexto.ListarPorId(id);
        }

    }
}

using System.Collections.Generic;
using System.Linq;
using Portal.Dominio;
using Portal.Dominio.Contrato;

namespace Portal.Repositorio
{
    public class PessoaRepositorioEF : IRepositorio<Pessoa>
    {
        private readonly ContextoPortal _contexto;

        public PessoaRepositorioEF()
        {
            _contexto = new ContextoPortal();
        }

        public void Salvar(Pessoa entidade)
        {
           _contexto.Pessoa.Add(entidade);
           _contexto.SaveChanges();

        }

        public void Excluir(Pessoa pessoa)
        {

            
        }

        public IEnumerable<Pessoa> ListarTodos()
        {
            return _contexto.Pessoa;
        }

        public Pessoa ListarPorId(int id)
        {
            
            return _contexto.Pessoa.First(x => x.PessoaId == id);

        }

    }
}

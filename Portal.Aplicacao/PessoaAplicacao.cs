using System.Collections.Generic;
using Portal.Dominio;
using Portal.Dominio.Contrato;

namespace Portal.Aplicacao
{
    public class PessoaAplicacao
    {
        private readonly IRepositorio<Pessoa> _contexto;
        

        public PessoaAplicacao(IRepositorio<Pessoa> repositorio)
        {
            _contexto = repositorio;
            
        }

        
        public IEnumerable<Pessoa> ListarTodasPalestras()
        {
            return _contexto.ListarTodos();
        }

        public void Salvar(Pessoa pessoa)
        {
            _contexto.Salvar(pessoa);
           
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Portal.Dominio;
using Portal.Dominio.Contrato;

namespace Portal.Repositorio
{
    public class PalestraRepositorioEF : IRepositorio<Palestra>
    {
        private readonly ContextoPortal contexto;

        public PalestraRepositorioEF()
        {
            contexto = new ContextoPortal();
        }

        public void Salvar(Palestra entidade)
        {
            if (entidade.PalestraId > 0)
            {
                var alterarPalestra = contexto.Palestras.First(x => x.PalestraId == entidade.PalestraId);
                alterarPalestra.Dia = entidade.Dia;
                alterarPalestra.Horario = entidade.Horario;
                alterarPalestra.Instituicao = entidade.Instituicao;
                alterarPalestra.Tema = entidade.Tema;
                
            }
            else
            {
                contexto.Palestras.Add(entidade);
            }
            contexto.SaveChanges();
        }

        public void Excluir(Palestra entidade)
        {

            var palestraExcluir = contexto.Palestras.First(x => x.PalestraId == entidade.PalestraId);
            contexto.Set<Palestra>().Remove(palestraExcluir);
            contexto.SaveChanges();
        }

        public IEnumerable<Palestra> ListarTodos()
        {
            return contexto.Palestras;
        }

        public Palestra ListarPorId(int id)
        {
            return contexto.Palestras.FirstOrDefault(x => x.PalestraId == id);
        }
    }
}

using Portal.Repositorio;

namespace Portal.Aplicacao
{
    public class Construtor
    {
        public static PalestraAplicacao PalestraAplicacaoEf()
        {
            return new PalestraAplicacao(new PalestraRepositorioEF());
            
        }

        public static PessoaAplicacao PessoaAplicacaoEf()
        {
            return new PessoaAplicacao(new PessoaRepositorioEF());

        }

        public static PalestranteAplicacao PalestranteAplicacaoEf()
        {
            return new PalestranteAplicacao(new PalestranteAplicacaoEF());

        }

    }
}

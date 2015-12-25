using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using Portal.Aplicacao;
using Portal.Dominio;
using Portal.Dominio.ViewModel;

namespace Portal.UI.Web.Controllers
{
    public class PessoasController : Controller
    {
        
        private readonly PalestraAplicacao _appPalestra;
        private readonly PessoaAplicacao _appPesssoa;
        private readonly PalestranteAplicacao _appPalestrante;

        public PessoasController()
        {
            _appPalestra = Construtor.PalestraAplicacaoEf();
            _appPesssoa = Construtor.PessoaAplicacaoEf();
            _appPalestrante = Construtor.PalestranteAplicacaoEf();
        }
        // GET: Pessoas
        public ActionResult Index()
        {
            return View(InicializarPalestras());
        }

        // GET: Pessoas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pessoas/Create
        public ActionResult Cadastro()
        {
            var pessoa = new Pessoa() {Palestras = new Collection<Palestra>()};
            ViewBag.Palestras = PopularPalestrasAssociadas(pessoa);
            return View(pessoa);
        }

        private List<PalestrasAssociadas> PopularPalestrasAssociadas(Pessoa pessoa)
        {
            var todasPalestras = _appPalestrante.ListarTodos();
            var palestraPessoa = new HashSet<int>(pessoa.Palestras.Select(c => c.PalestraId));
            var viewModel = new List<PalestrasAssociadas>();
            foreach (var palestra in todasPalestras)
            {
                viewModel.Add(new PalestrasAssociadas
                {
                    Palestrante = palestra,
                    Associada = palestraPessoa.Contains(palestra.PalestranteId)

                });
            }
            return viewModel;
        }

        // POST: Pessoas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro([Bind(Exclude = "Palestras")] Pessoa pessoa, int[] palestraSelecionadas)
        {
            pessoa.Palestras = new List<Palestra>();
            foreach (var palestraSelecionada in palestraSelecionadas)
            {
                var palestra = _appPalestrante.ListarTodos().FirstOrDefault(x => x.PalestranteId == palestraSelecionada);
                pessoa.PalestraId = palestra.PalestranteId;
                _appPesssoa.Salvar(pessoa);
            }
            return RedirectToAction("Cadastro", "Pessoas");
        }

        // GET: Pessoas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pessoas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pessoas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private PalestrasViewModel InicializarPalestras()
        {
            var model = new PalestrasViewModel();
            var todasPalestras = new List<Palestra>();
            var pessoa = new Pessoa();
            
            model.Palestras = _appPalestra.ListarTodos();
            model.PalestrasSelecionadas = todasPalestras;
            model.Pessoa = pessoa;

            return model;
        }

        private PalestrasViewModel PegarPelastraModel(PalestrasAdicionadas palestrasAdicionadas)
        {
            var model = new PalestrasViewModel();
            var palestrasSelecionadas = new List<Palestra>();
            var palestrasIds = new string[0];

            if(palestrasAdicionadas == null) palestrasAdicionadas = new PalestrasAdicionadas();


            if (palestrasAdicionadas.PalestraIds != null && palestrasAdicionadas.PalestraIds.Any())
            {
                palestrasIds = palestrasAdicionadas.PalestraIds;
            }

            if (palestrasIds.Any())
            {
                palestrasSelecionadas =
                    _appPalestra.ListarTodos()
                        .Where(x => palestrasIds.Any(s => x.PalestraId.ToString().Equals(s)))
                        .ToList();
            }

            model.Palestras = _appPalestra.ListarTodos().ToList();
            model.PalestrasSelecionadas = palestrasSelecionadas;
            model.PalestrasAdicionadas = palestrasAdicionadas;

            return model;

        }
    }
}

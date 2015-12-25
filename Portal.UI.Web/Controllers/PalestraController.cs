using System.Web.Mvc;
using Portal.Aplicacao;
using Portal.Dominio;

namespace Portal.UI.Web.Controllers
{
    public class PalestraController : Controller
    {

        private readonly PalestranteAplicacao _appPalestranteAplicacao;

        public PalestraController()
        {
            _appPalestranteAplicacao = Construtor.PalestranteAplicacaoEf();
        }
        // GET: Palestra
        public ActionResult Index()
        {
            var listarPalestra = _appPalestranteAplicacao.ListarTodos();
            return View(listarPalestra);
        }

        // GET: Palestra/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Palestra/Create
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: Palestra/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Palestrante palestrante)
        {
            if (ModelState.IsValid)
            {
                _appPalestranteAplicacao.Salvar(palestrante);
                return RedirectToAction("Index");
            }
            return View(palestrante);
        }

        // GET: Palestra/Edit/5
        public ActionResult Editar(int id)
        {
            var palestra = _appPalestranteAplicacao.ListarPorId(id);
            if (palestra == null)
                return HttpNotFound();
            return View(palestra);
        }

        // POST: Palestra/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Palestrante palestrante)
        {
            if (ModelState.IsValid)
            {
                _appPalestranteAplicacao.Salvar(palestrante);
                return RedirectToAction("Index");
            }
            return View(palestrante);
        }

        // GET: Palestra/Delete/5
        public ActionResult Excluir(int id)
        {
            var palestra = _appPalestranteAplicacao.ListarPorId(id);
            if (palestra == null)
                return HttpNotFound();

            return View(palestra);
            
        }

        // POST: Palestra/Delete/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(int id)
        {
            var palestra = _appPalestranteAplicacao.ListarPorId(id);
            _appPalestranteAplicacao.Excluir(palestra);

            return RedirectToAction("Index");
        }
    }
}

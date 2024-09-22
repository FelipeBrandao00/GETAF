using GETAF.Helper;
using Microsoft.AspNetCore.Mvc;

namespace GETAF.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISessao _sessao;
        public HomeController(ISessao sessao)
        {
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            var usuario = _sessao.BuscarSessaoUsuario("SessaoUsuarioLogado");

            if(usuario == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ViewBag.UsuarioNome = usuario?.Nome ?? "Visitante";
            return View();
        }
    }
}

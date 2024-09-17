using GETAF.Helper;
using GETAF.Models;
using GETAF.Models.Context;
using GETAF.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GETAF.Controllers {
    public class LoginController : Controller {

        private readonly ISessao _Sessao;
        public LoginController(ISessao Sessao)
        {
            _Sessao = Sessao;
        }
         
        public IActionResult Index() {
            
            return View();
        }

        public JsonResult ValidarLogin([FromBody] LoginModel login) {
            var retorno = login.ValidarLogin();
            return Json(retorno);
        }

        //Criar funcao "Entrar", e adicionar "CriarSessaoUsuario"

        public IActionResult Login([FromBody] LoginModel login)
        {
            var entrada = login.Login();
            return Json(entrada);
        }


    }
}

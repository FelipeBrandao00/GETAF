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

        public IActionResult ValidarLogin([FromBody] LoginModel login) {

            var retorno = login.ValidarLogin();
            return Json(retorno);
        }
    }
}

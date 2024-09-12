using GETAF.Models;
using GETAF.Models.Context;
using GETAF.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GETAF.Controllers {
    public class LoginController : Controller {
        public IActionResult Index() {
            
            return View();
        }

        public JsonResult ValidarLogin([FromBody] LoginModel login) {
            var retorno = login.ValidarLogin();
            return Json(retorno);
        }
    }
}

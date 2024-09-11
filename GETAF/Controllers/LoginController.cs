using GETAF.Models;
using GETAF.Models.Context;
using GETAF.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GETAF.Controllers {
    public class LoginController : Controller {
        public IActionResult Index() {
            //using (var _context = new AppDbContext()) {
            //    var passwordInserida = "naofaznada";
            //    var emailInserido = "azeitona.planetaterra@gmail.com";

            //    var hash = Hash.GerarHashSalt(passwordInserida, out byte[] salt);

            //    _context.Usuarios.Add(
            //        new Models.Entities.Usuario { 
            //            Nome = "Azeitona",
            //            Email = emailInserido,
            //            Senha = hash,
            //            IsAtivo = true,
            //            Foto = null,
            //            Salt = salt
            //        });

            //    _context.SaveChanges();
            //}
            return View();
        }

        public JsonResult ValidarLogin([FromBody] LoginModel login) {
            var retorno = login.ValidarLogin();
            return Json(retorno);
        }
    }
}

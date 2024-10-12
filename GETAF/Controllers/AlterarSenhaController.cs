using GETAF.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GETAF.Controllers
{
    public class AlterarSenhaController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RedefinirSenha([FromBody] AlterarSenhaModel alterarSenhaModel)
        {
            var email = TempData["EmailUsuario"] as string;
            var resposta = alterarSenhaModel.RedefinirSenha(email);

            return Json(new { sucesso = resposta.Sucesso, mensagem = resposta.Mensagem });
        }
    }
}

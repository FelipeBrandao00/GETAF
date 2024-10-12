using GETAF.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GETAF.Controllers
{
    public class CodigoSenhaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VerificarCodigo([FromBody] CodigoSenhaModel codigoSenhaModel)
        {
            var codigoGerado = HttpContext.Session.GetString("CodigoGerado");
            var resposta = codigoSenhaModel.VerificarCodigo(codigoGerado);

            return Json(new { sucesso = resposta.Sucesso, mensagem = resposta.Mensagem });
        }
    }
}

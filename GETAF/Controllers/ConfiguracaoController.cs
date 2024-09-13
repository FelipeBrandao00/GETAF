using GETAF.Models;
using GETAF.Models.Context;
using GETAF.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GETAF.Controllers
{
    public class ConfiguracaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult EditarNome([FromBody] ConfiguracaoModel config)
        {
            var retorno = config.EditarNome();
            return Json(retorno);
        }

        public JsonResult EditarEmail([FromBody] ConfiguracaoModel config)
        {
            var retorno = config.EditarEmail();
            return Json(retorno);
        }

        public JsonResult EditarSenha([FromBody] ConfiguracaoModel config)
        {
            var retorno = config.EditarPassword();
            return Json(retorno);
        }

        public JsonResult EditarFoto([FromBody] ConfiguracaoModel config)
        {
            var retorno = config.EditarFoto();
            return Json(retorno);
        }
    }
}
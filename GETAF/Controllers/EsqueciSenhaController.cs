using GETAF.Helper;
using GETAF.Models;
using GETAF.Models.Context;
using GETAF.Models.Entities;
using GETAF.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Web.Helpers;

namespace GETAF.Controllers
{
    public class EsqueciSenhaController : Controller
    {
        private readonly IEmail _email;
        public string CodigoGerado;

        public EsqueciSenhaController(IEmail email)
        {
            _email = email;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ReceberCodigo([FromBody] EsqueciSenhaModel esqueciSenhaModel)
        {
            var (usuario, resposta) = esqueciSenhaModel.ReceberCodigo();
            var emailCapturado = usuario.Email;

            TempData["EmailUsuario"] = emailCapturado;

            if (resposta.Sucesso)
            {
                CodigoGerado = (Guid.NewGuid().ToString().Substring(0, 8)).ToUpper();
                HttpContext.Session.SetString("CodigoGerado", CodigoGerado);
                bool emailEnviado = await _email.EnviarAsync(usuario.Email, "Código para redefinir senha", $"Seu código para redefinir a senha é: {CodigoGerado}");

                if (emailEnviado)
                {
                    return Json(new { sucesso = resposta.Sucesso && emailEnviado, mensagem = resposta.Mensagem });
                }
            }

            return Json(new { sucesso = resposta.Sucesso, mensagem = resposta.Mensagem });
        }
    }
}

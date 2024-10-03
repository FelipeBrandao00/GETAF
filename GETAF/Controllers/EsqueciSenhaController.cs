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

            if (resposta.Sucesso)
            {
                string codigo = (Guid.NewGuid().ToString().Substring(0, 8));
                bool emailEnviado = await _email.EnviarAsync(usuario.Email, "Código para redefinir senha", $"Seu código para redefinir a senha é: {codigo.ToUpper()}");

                if (emailEnviado)
                {
                    return Json(new { sucesso = resposta.Sucesso && emailEnviado, mensagem = resposta.Mensagem });
                }
            }

            return Json(new { sucesso = resposta.Sucesso, mensagem = resposta.Mensagem });
        }
    }
}

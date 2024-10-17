using GETAF.Helper;
using GETAF.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GETAF.Controllers
{
    public class AlterarSenhaController : Controller
    {

        private readonly ISessao _sessao;
        public AlterarSenhaController(ISessao sessao)
        {
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RedefinirSenha([FromBody] AlterarSenhaModel alterarSenhaModel)
        {
            string email;

            var usuario = _sessao.BuscarSessaoUsuario("SessaoUsuarioLogado");

            if(usuario != null)
            {
                email = usuario.Email;
                var resposta = alterarSenhaModel.RedefinirSenha(email);

                _sessao.RemoverSessaoUsuario("SessaoUsuarioLogado");
                return Json(new { sucesso = resposta.Sucesso, mensagem = resposta.Mensagem });
            }
            else
            {
                email = TempData["EmailUsuario"] as string;
                var resposta = alterarSenhaModel.RedefinirSenha(email);

                return Json(new { sucesso = resposta.Sucesso, mensagem = resposta.Mensagem });
            }
        }
    }
}

using GETAF.Helper;
using GETAF.Models;
using GETAF.Models.Context;
using GETAF.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GETAF.Controllers {
    public class LoginController : Controller {

        private readonly ISessao _sessao;
        public LoginController(ISessao sessao)
        {
            _sessao = sessao;
        }
         
        public IActionResult Index() {

            _sessao.RemoverSessaoUsuario("SessaoUsuarioLogado");
            return View();
        }

        public IActionResult ValidarLogin([FromBody] LoginModel login)
        {
            var (usuario, resposta) = login.ValidarLogin();
            
            if(resposta.Sucesso)
            {
                _sessao.CriarSessaoUsuario("SessaoUsuarioLogado", usuario);
                return Json(new { sucesso = true });
            }
            return Json(new { sucesso = false, mensagem = resposta.Mensagem });
        }
    }
}

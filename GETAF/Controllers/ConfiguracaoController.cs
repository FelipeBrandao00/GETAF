using GETAF.Helper;
using GETAF.Models;
using GETAF.Models.Context;
using GETAF.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GETAF.Controllers
{
    public class ConfiguracaoController : Controller
    {

        private readonly ISessao _sessao;
        public ConfiguracaoController(ISessao sessao)
        {
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DeletarConta()
        {
            return View();
        }

        public JsonResult EditarNome([FromBody] ConfiguracaoModel config)
        {
            var usuario = _sessao.BuscarSessaoUsuario("SessaoUsuarioLogado");
            var resposta = config.EditarNome(usuario);

            if (resposta.Sucesso)
                _sessao.AtualizarSessaoUsuario("SessaoUsuarioLogado");

            return Json(new { sucesso = resposta.Sucesso, mensagem = resposta.Mensagem });
        }

        public JsonResult DeletarContaUsuario()
        {
            var config = new ConfiguracaoModel();
            var usuario = _sessao.BuscarSessaoUsuario("SessaoUsuarioLogado");
            var resposta = config.DeletarContaUsuario(usuario);

            if(resposta.Sucesso)
            {
                _sessao.RemoverSessaoUsuario("SessaoUsuarioLogado");
            }

            return Json(new { sucesso = resposta.Sucesso, mensagem = resposta.Mensagem });
        }

        //public JsonResult EditarFoto(ConfiguracaoModel config)
        //{
        //    var resposta = config.EditarFoto();

        //    return Json(resposta);
        //}
    }
}
using GETAF.Helper;
using GETAF.Models.Context;
using GETAF.Models.Entities;
using GETAF.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GETAF.Controllers {
    public class GrupoController(AppDbContext _context, ISessao _sessao) : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult DetalhesGrupo() {
            return View();
        }

        [HttpPost]
        public IActionResult CriarGrupo([FromBody] GrupoModel grupoModel) {
            var usuario = _sessao.BuscarSessaoUsuario("SessaoUsuarioLogado");
            var resposta = grupoModel.CriarGrupo(_context, usuario.Id);
            return Json(new { sucesso = resposta.Sucesso, mensagem = resposta.Mensagem });
        }

        public IActionResult ListarGrupos() {
            var grupos = _context.Grupos.ToList();
            return PartialView("_ListaGrupos", grupos);
        }


    }
}

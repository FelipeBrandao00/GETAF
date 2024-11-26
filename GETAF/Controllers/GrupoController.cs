using GETAF.Helper;
using GETAF.Models.Context;
using GETAF.Models.Entities;
using GETAF.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace GETAF.Controllers {
    public class GrupoController(AppDbContext _context, ISessao _sessao) : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult DetalhesGrupo([FromQuery]int grupoId) {
            var grupo = _context.Grupos.Find(grupoId);
            var usuarioLogado = _sessao.BuscarSessaoUsuario("SessaoUsuarioLogado");

            ViewBag.IdUsuarioLogado = usuarioLogado.Id;

            return View(grupo);
        }

        public IActionResult EditarGrupo([FromQuery] int grupoId) {
            var grupo = _context.Grupos.Find(grupoId);
            var usuarioLogado = _sessao.BuscarSessaoUsuario("SessaoUsuarioLogado");

            ViewBag.IdUsuarioLogado = usuarioLogado.Id;
            return View(grupo);
        }

        public IActionResult ExcluirGrupo([FromQuery] int grupoId) {
            var grupo = _context.Grupos.Find(grupoId);
            var usuarioLogado = _sessao.BuscarSessaoUsuario("SessaoUsuarioLogado");

            ViewBag.IdUsuarioLogado = usuarioLogado.Id;
            return View(grupo);
        }

        [HttpPost]
        public IActionResult CriarGrupo([FromBody] GrupoModel grupoModel) {
            var usuario = _sessao.BuscarSessaoUsuario("SessaoUsuarioLogado");
            var resposta = grupoModel.CriarGrupo(_context, usuario.Id);
            
            return Json(new { sucesso = resposta.Sucesso, mensagem = resposta.Mensagem });
        }

        [HttpPost]
        public IActionResult EditarGrupo([FromBody] GrupoModel grupoModel) {
            var usuario = _sessao.BuscarSessaoUsuario("SessaoUsuarioLogado");
            var resposta = grupoModel.EditarGrupo(_context);

            ViewBag.IdUsuarioLogado = usuario.Id;
            return Json(new { sucesso = resposta.Sucesso, mensagem = resposta.Mensagem });
        }

        [HttpPost]
        public IActionResult ExcluirGrupo([FromBody] GrupoModel grupoModel) {
            var usuario = _sessao.BuscarSessaoUsuario("SessaoUsuarioLogado");
            var resposta = grupoModel.ExcluirGrupo(_context);
            var usuarioLogado = _sessao.BuscarSessaoUsuario("SessaoUsuarioLogado");

            ViewBag.IdUsuarioLogado = usuarioLogado.Id;
            return Json(new { sucesso = resposta.Sucesso, mensagem = resposta.Mensagem });
        }

        public IActionResult ListarGrupos() {
            var usuarioLogado = _sessao.BuscarSessaoUsuario("SessaoUsuarioLogado");
            var grupos = _context.Grupos
                   .Where(g => g.GrupoUsuarios.Any(gu => gu.UsuarioId == usuarioLogado.Id)
                   && g.IsAtivo == true)
                   .ToList();
            return PartialView("_ListaGrupos", grupos);
        }

        public IActionResult BuscarQuadroTarefas() {
            return PartialView("_QuadroTarefas");
        }

    }
}

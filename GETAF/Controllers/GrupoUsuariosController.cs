using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GETAF.Models.Context;
using GETAF.Models.Entities;
using GETAF.Models.ViewModel;
using GETAF.Helper;

namespace GETAF.Controllers
{
    public class GrupoUsuariosController(AppDbContext _context, ISessao _sessao) : Controller
    {
        public async Task<IActionResult> AddMembros ([FromBody] GrupoUsuariosModel request )
        {            
            var resposta = request.AddMembro(_context);
            return Json(new { sucesso = resposta.Sucesso, mensagem = resposta.Mensagem });
        }

        public async Task<IActionResult> ExcluirMembros ([FromBody] GrupoUsuariosModel request)
        {
            var resposta = request.ExcluirMembro(_context);
            return Json(new { sucesso = resposta.Sucesso, mensagem = resposta.Mensagem });
        }

        public IActionResult Membros([FromQuery] int grupoId)
        {
            var grupo = _context.Grupos
                .Include(x => x.Usuario)
                .Where(X => X.Id == grupoId)
                .FirstOrDefault();

            var usuarioLogado = _sessao.BuscarSessaoUsuario("SessaoUsuarioLogado");
            ViewBag.IdUsuarioLogado = usuarioLogado.Id;
            return View(grupo);
        }

        public IActionResult ListarMembros(int grupoId) {
            var criador = _context.Grupos.Where(x => x.Id == grupoId).Select(x => x.UsuarioId).FirstOrDefault();
            var membros = _context.GrupoUsuarios.Include(x => x.Usuario).Where(x => x.GrupoId == grupoId && x.UsuarioId != criador).ToList();

            var usuarioLogado = _sessao.BuscarSessaoUsuario("SessaoUsuarioLogado");
            ViewBag.IdUsuarioLogado = usuarioLogado.Id;
            ViewBag.CriadorId = criador;

            return PartialView("_ListaMembros", membros);
        }
    }
}

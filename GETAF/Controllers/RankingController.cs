using GETAF.Helper;
using GETAF.Models.Context;
using GETAF.Models.Entities;
using GETAF.Models.Rankings;
using GETAF.Models.ViewModel;


using Microsoft.AspNetCore.Mvc;

namespace GETAF.Controllers
{
    public class RankingController(AppDbContext _context, ISessao _sessao) : Controller {

        public IActionResult Index(int grupoId) {
            var grupo = _context.Grupos.Find(grupoId);
            var usuarioLogado = _sessao.BuscarSessaoUsuario("SessaoUsuarioLogado");

            ViewBag.grupoId = grupoId;
            ViewBag.isAdmin = grupo.UsuarioId == usuarioLogado.Id;
            return View();
        }

        public IActionResult RankingMembro() {
            return View();
        }

        public IActionResult CarregarRanking([FromBody]RankingViewModel rkg) {
            var lstRanking = new RankingViewModel().BuscarRanking(_context, rkg.GrupoId);
            ViewBag.ListaRanking = lstRanking;
            return View("_Ranking");
        }

        //[HttpPost]
        //public IActionResult Pontuar([FromBody] RankingViewModel rkg, int dificuldade)
        //{
        //    var resposta = rkg.Pontuar(_context, dificuldade);
        //    return Json(new { sucesso = resposta.Sucesso, mensagem = resposta.Mensagem });
        //}
    }
}

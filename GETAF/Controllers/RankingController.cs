using GETAF.Helper;
using GETAF.Models.Context;
using GETAF.Models.Entities;
using GETAF.Models.Rankings;
using GETAF.Models.ViewModel;


//using GETAF.Models.Ranking;
using Microsoft.AspNetCore.Mvc;

namespace GETAF.Controllers
{
    public class RankingController(AppDbContext _context, ISessao _sessao) : Controller {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RankingMembro()
        {
            return View();
        }

        public IActionResult VerRanking(int grupoId) {
            return View("_Ranking");
        }

        public IActionResult RankingMembros(int grupoId)
        {
            return View(grupoId);
        }

        [HttpPost]
        public IActionResult Pontuar([FromBody] RankingViewModel rkg, int dificuldade)
        {
            var resposta = rkg.Pontuar(_context, dificuldade);
            return Json(new { sucesso = resposta.Sucesso, mensagem = resposta.Mensagem });
        }

    }
}

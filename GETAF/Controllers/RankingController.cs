using GETAF.Models.Context;
using GETAF.Models.Entities;
using GETAF.Models.Rankings;
using GETAF.Models.ViewModel;


//using GETAF.Models.Ranking;
using Microsoft.AspNetCore.Mvc;

namespace GETAF.Controllers
{
    public class RankingController : Controller
    {
       //  private readonly AppDbContext _context;
       //
       //  public RankingController (AppDbContext context)
       //  {
       //      _context = context;
       //  }
       //
       //  //public async Task<IActionResult> Pontuar([FromBody] RankingAluno request)
       //  //{
       //  //    var resposta = 
       // // }
       //  public IActionResult Index()
       //  {
       //      return View();
       //  }
       //
       //  public IActionResult RankingTodosGrupos()
       //  {
       //      return View();
       //  }
       //
       //  public IActionResult RankingMembros(int grupoId)
       //  {
       //      return View(grupoId);
       //  }
       //
       //  [HttpPost]
       //  public IActionResult Pontuar([FromBody] RankingViewModel rkg, int dificuldade)
       //  {
       //      var resposta = rkg.Pontuar(_context, dificuldade);
       //      return Json(new { sucesso = resposta.Sucesso, mensagem = resposta.Mensagem });
       //  }

       public IActionResult Ranking()
       {
           throw new NotImplementedException();
       }
    }
}

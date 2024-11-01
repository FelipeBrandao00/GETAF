using GETAF.Models.Context;
using Microsoft.AspNetCore.Mvc;

namespace GETAF.Controllers
{
    public class TarefaController : Controller
    {
        private readonly AppDbContext _context;
        public TarefaController(AppDbContext context) { _context = context; }
        public IActionResult Index()
        {
            var tarefas = _context.Tarefas.ToList();
            return View(tarefas);
        }
    }
}

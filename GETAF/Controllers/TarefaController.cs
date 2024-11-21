using GETAF.Models.Context;
using GETAF.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GETAF.Controllers
{
    public class TarefaController : Controller
    {
        private readonly AppDbContext _context;
        public TarefaController(AppDbContext context) { _context = context; }
   
        public IActionResult AddTarefa([FromBody] TarefaViewModel tarefaViewModel) {
            var tarefa = tarefaViewModel.CriarTarefa(_context);
            return Json(new { sucesso = (tarefa != null), mensagem = tarefa == null ? "Erro ao tentar adicionar a tarefa" : "Sucesso" });
        }
        public IActionResult ListarTarefas([FromBody] TarefaViewModel tarefaViewModel) {
            var tarefas = tarefaViewModel.ListarTarefas(_context);
            return Json(new { tarefas = tarefas });
        }
        public IActionResult UpdateTarefa([FromBody] TarefaViewModel tarefaViewModel) {
            var tarefa = tarefaViewModel.AtualizarTarefa(_context);
            return Json(new { sucesso = (tarefa != null), mensagem = tarefa == null ? "Erro ao tentar atualizar a tarefa" : "Sucesso" });
        }

        public IActionResult AtualizarStatusTarefa([FromBody] TarefaViewModel tarefaViewModel) {
            var tarefa = tarefaViewModel.AtualizarStatus(_context);
            return Json(new { sucesso = (tarefa != null), mensagem = tarefa == null ? "Erro ao tentar atualizar o status da tarefa" : "Sucesso" });
        }

        public IActionResult ExcluirTarefa([FromBody] TarefaViewModel tarefaViewModel) {
            var tarefa = tarefaViewModel.ExcluirTarefa(_context);
            return Json(new { sucesso = (tarefa != null), mensagem = tarefa == null ? "Erro ao tentar excluir a tarefa" : "Sucesso" });
        }

        public IActionResult TarefasGeral ()
        {
            return View();
        }
    }
}

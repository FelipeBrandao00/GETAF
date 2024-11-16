using GETAF.Helper;
using GETAF.Models.Context;
using GETAF.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GETAF.Controllers {
    public class QuizController(AppDbContext _context, ISessao _sessao) : Controller {
        public IActionResult Index() {
            ViewBag.grupoId = 1;
            return View();
        }
        public IActionResult CriarQuiz([FromBody] QuizViewModel quizModel) {
            var usuarioLogado = _sessao.BuscarSessaoUsuario("SessaoUsuarioLogado");
            quizModel.UsuarioId = usuarioLogado.Id;
            var resposta = quizModel.CriarQuiz(_context);
            return Json(new { sucesso = resposta.Sucesso, mensagem = resposta.Mensagem });
        }

        public IActionResult EditarQuiz([FromBody] QuizViewModel quizModel) {
            var usuarioLogado = _sessao.BuscarSessaoUsuario("SessaoUsuarioLogado");
            quizModel.UsuarioId = usuarioLogado.Id;
            var resposta = quizModel.UpdateQuiz(_context);
            return Json(new { sucesso = resposta.Sucesso, mensagem = resposta.Mensagem });
        }

        public IActionResult ListarQuizesAbertosPerguntas([FromBody] QuizViewModel quizModel) {
            var usuarioLogado = _sessao.BuscarSessaoUsuario("SessaoUsuarioLogado");
            var quizes = _context.Quiz
                   .Where(q => q.GrupoId == quizModel.GrupoId && q.IsAbertoResposta == false)
                   .ToList();
            return PartialView("_ListaQuiz", quizes);
        }

        public IActionResult ListarQuizesAbertosRespostas([FromBody] QuizViewModel quizModel) {
            var usuarioLogado = _sessao.BuscarSessaoUsuario("SessaoUsuarioLogado");
            var quizes = _context.Quiz
                   .Where(q => q.GrupoId == quizModel.GrupoId && q.IsAbertoResposta == true)
                   .ToList();
            return PartialView("_ListaQuizResposta", quizes);
        }

        public IActionResult UpdateQuiz([FromBody] QuizViewModel quizModel) {
            return null;
        }

        public IActionResult ExcluirQuiz([FromBody] QuizViewModel quizModel) {
            return null;
        }
    }
}

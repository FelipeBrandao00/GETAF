using GETAF.Helper;
using GETAF.Models.Context;
using GETAF.Models.Entities;
using GETAF.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GETAF.Controllers {
    public class QuizController(AppDbContext _context, ISessao _sessao) : Controller {
        public IActionResult Index(int grupoId) {
            ViewBag.grupoId = grupoId;
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

        public IActionResult HabilitarQuizRespostas([FromBody] QuizViewModel quizModel) {
            var resposta = quizModel.HabilitarQuizRespostas(_context);
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

            quizes = quizes.Where(x => PerguntaViewModel.ListarPerguntasNaoRespondidas(_context, x.Id, usuarioLogado.Id).Count > 0).ToList();
            return PartialView("_ListaQuizResposta", quizes);
        }

        public IActionResult ListarQuizesRespondidos([FromBody] QuizViewModel quizModel) {
            var usuarioLogado = _sessao.BuscarSessaoUsuario("SessaoUsuarioLogado");
            var quizes = _context.Quiz
                   .Where(q => q.GrupoId == quizModel.GrupoId && q.IsAbertoResposta == true)
            .ToList();

            var retorno = new List<(string, string)>();

            quizes = quizes.Where(x => PerguntaViewModel.ListarPerguntasNaoRespondidas(_context, x.Id, usuarioLogado.Id).Count == 0).ToList();

            foreach (var quiz in quizes) {
                int totalPerguntas = _context.Perguntas.Where(x => x.QuizId == quiz.Id).Count();

                int totalAcertosUsuario = _context.RespostaUsuario
                    .Where(resposta =>
                        resposta.UsuarioId == usuarioLogado.Id &&
                        resposta.Alternativa != null &&
                        resposta.Alternativa.Pergunta.QuizId == quiz.Id &&
                        resposta.Alternativa.IsCorreta)
                    .Count();

                retorno.Add((quiz.Titulo, $"{totalAcertosUsuario}/{totalPerguntas}"));
            }
            return PartialView("_ListaQuizRespondido", retorno);
        }

        public IActionResult UpdateQuiz([FromBody] QuizViewModel quizModel) {
            return null;
        }

        public IActionResult ExcluirQuiz([FromBody] QuizViewModel quizModel) {
            return null;
        }
    }
}

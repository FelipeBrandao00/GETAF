using GETAF.Helper;
using GETAF.Models.Context;
using GETAF.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GETAF.Controllers {
    public class PerguntaController(AppDbContext _context, ISessao _sessao) : Controller {
        public IActionResult Index([FromQuery] int quizId) {
            return View(quizId);
        }

        public IActionResult ResponderPerguntas([FromQuery] int quizId) {
            var usuarioLogado = _sessao.BuscarSessaoUsuario("SessaoUsuarioLogado");

            var perguntasNaoRespondidas = _context.Perguntas
            .Where(p => p.QuizId == quizId)
            .Where(p => !_context.RespostaUsuario
                .Where(ru => ru.UsuarioId == usuarioLogado.Id)
                .Select(ru => ru.PerguntaId)
                .Contains(p.Id))
            .Include(p => p.Alternativas)
            .ToList();

            ViewBag.QuizName = _context.Quiz.Where(x => x.Id == quizId).Select(x => x.Titulo).FirstOrDefault();

            return View(perguntasNaoRespondidas);
        }

        public IActionResult CriarPergunta([FromBody] PerguntaViewModel perguntaModel) {
            var resposta = perguntaModel.CriarPergunta(_context);
            return Json(new { sucesso = resposta.Sucesso, mensagem = resposta.Mensagem });
        }

        public async Task<IActionResult> SubmitAnswers([FromBody] List<RespostaQuizDTO> respostas) {
            try {
                // Processa as respostas aqui
                // Salva no banco de dados, etc.

                return Json(new { success = true, redirectUrl = "/Quiz/Resultado" });
            }
            catch (Exception ex) {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }

    public class RespostaQuizDTO {
        public int PerguntaId { get; set; }
        public int AlternativaId { get; set; }
    }
}

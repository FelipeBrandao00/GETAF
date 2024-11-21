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

            var perguntasNaoRespondidas = PerguntaViewModel.ListarPerguntasNaoRespondidas(_context, quizId,usuarioLogado.Id);

            ViewBag.QuizName = _context.Quiz.Where(x => x.Id == quizId).Select(x => x.Titulo).FirstOrDefault();

            return View(perguntasNaoRespondidas);
        }

        public IActionResult CriarPergunta([FromBody] PerguntaViewModel perguntaModel) {
            var resposta = perguntaModel.CriarPergunta(_context);
            return Json(new { sucesso = resposta.Sucesso, mensagem = resposta.Mensagem });
        }

        public async Task<IActionResult> EnviarResposta([FromBody] List<RespostaQuizDTO> respostas) {
            PerguntaViewModel perguntaModel = new PerguntaViewModel{ Respostas = respostas };
            var usuarioLogado = _sessao.BuscarSessaoUsuario("SessaoUsuarioLogado");
            var resposta = perguntaModel.GravarResposta(_context, usuarioLogado.Id);
            return Json(new { sucesso = resposta.Sucesso, mensagem = resposta.Mensagem });
        }
    }
}

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

            var quiz = _context.Quiz.Where(x => x.Id == quizId).FirstOrDefault();
            ViewBag.QuizName = quiz.Titulo;
            ViewBag.GrupoId = quiz.GrupoId;

            return View(perguntasNaoRespondidas);
        }

        public IActionResult CriarPergunta([FromBody] PerguntaViewModel perguntaModel) {
            var resposta = perguntaModel.CriarPergunta(_context);
            return Json(new { sucesso = resposta.Sucesso, mensagem = resposta.Mensagem });
        }

        [HttpPost]
        public async Task<IActionResult> EnviarResposta([FromBody] EnviarRespostaRequest request) {
            PerguntaViewModel perguntaModel = new PerguntaViewModel { Respostas = request.Respostas };
            var usuarioLogado = _sessao.BuscarSessaoUsuario("SessaoUsuarioLogado");
            var resposta = await perguntaModel.GravarRespostaAsync(_context, usuarioLogado.Id, request.GrupoId);
            return Json(new { sucesso = resposta.Sucesso, mensagem = resposta.Mensagem });
        }


        public class EnviarRespostaRequest {
            public List<RespostaQuizDTO> Respostas { get; set; }
            public int GrupoId { get; set; }
        }
    }
}

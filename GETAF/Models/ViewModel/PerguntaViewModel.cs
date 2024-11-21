using GETAF.Models.Context;
using GETAF.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GETAF.Models.ViewModel {
    public class PerguntaViewModel {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public string Descricao { get; set; } = "";
        public List<Alternativa> Alternativas { get; set; }
        public int Dificuldade { get; set; }
        public List<RespostaQuizDTO> Respostas { get; set; }



        public Resposta CriarPergunta(AppDbContext _context) {

            var pergunta = new Pergunta
            {
                Descricao = Descricao,
                QuizId = QuizId,
                Dificuldade = Dificuldade,
            };

            _context.Perguntas.Add(pergunta);
            _context.SaveChanges();

            Alternativas.ForEach(al => al.PerguntaId = pergunta.Id);

            CriarAlternativas(_context);
            return new Resposta(); 
        }

        private void CriarAlternativas(AppDbContext _context) {
            _context.Alternativas.AddRange(Alternativas);
            _context.SaveChanges();
        }

        public Resposta GravarResposta(AppDbContext _context, int usuarioId) {
            try {
                foreach (var resposta in Respostas) {
                    _context.RespostaUsuario.Add(
                    new RespostaUsuario{
                        AlternativaId = resposta.AlternativaId,
                        PerguntaId = resposta.PerguntaId,
                        UsuarioId = usuarioId
                    });
                    _context.SaveChanges();
                }
                return new Resposta(true, "Quiz Respondido com sucesso!");
            }
            catch (Exception ex) {
                return new Resposta(false, "Algo deu errado tentando responder o quiz!");
            }
        }

        public static List<Pergunta> ListarPerguntasNaoRespondidas(AppDbContext _context, int quizId, int usuarioId) {
            return _context.Perguntas
           .Where(p => p.QuizId == quizId)
           .Where(p => !_context.RespostaUsuario
               .Where(ru => ru.UsuarioId == usuarioId)
               .Select(ru => ru.PerguntaId)
               .Contains(p.Id))
           .Include(p => p.Alternativas)
           .ToList();
        }

        public static void BuscarTotalAcertosQuiz(AppDbContext _context, int quizId, int usuarioId) {

        }
    }

    public class RespostaQuizDTO {
        public int PerguntaId { get; set; }
        public int AlternativaId { get; set; }
    }
}

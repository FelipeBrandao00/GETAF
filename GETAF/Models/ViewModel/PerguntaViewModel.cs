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

        public async Task<Resposta> GravarRespostaAsync(AppDbContext _context, int usuarioId, int grupoId) {
            try {
                var respostasUsuario = Respostas.Select(r => new RespostaUsuario
                {
                    AlternativaId = r.AlternativaId,
                    PerguntaId = r.PerguntaId,
                    UsuarioId = usuarioId
                }).ToList();

                await _context.RespostaUsuario.AddRangeAsync(respostasUsuario);
                await _context.SaveChangesAsync();

                var alternativasCorretas = await _context.Alternativas
                    .Where(a => respostasUsuario.Select(r => r.AlternativaId).Contains(a.Id) && a.IsCorreta)
                    .Include(a => a.Pergunta)
                    .ToListAsync();

                if (alternativasCorretas.Any()) {
                    var ranking = await _context.Ranking
                        .FirstOrDefaultAsync(x => x.GrupoId == grupoId && x.UsuarioId == usuarioId);

                    if (ranking == null) {
                        ranking = new Ranking
                        {
                            UsuarioId = usuarioId,
                            GrupoId = grupoId,
                            Pontos = 0
                        };
                        _context.Ranking.Add(ranking);
                    }

                    ranking.Pontos += alternativasCorretas.Sum(alt => alt.Pergunta.Dificuldade switch {
                        1 => 1,
                        2 => 3,
                        _ => 6
                    });

                    await _context.SaveChangesAsync();
                }

                return new Resposta(true, "Quiz respondido com sucesso!");
            }
            catch (Exception ex) {
                // Considere logar a exceção aqui
                return new Resposta(false, "Algo deu errado ao responder o quiz!");
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

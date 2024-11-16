using GETAF.Models.Context;
using GETAF.Models.Entities;

namespace GETAF.Models.ViewModel {
    public class PerguntaViewModel {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public required string Descricao { get; set; } = "";
        public virtual List<Alternativa> Alternativas { get; set; }
        public int Dificuldade { get; set; }



        public Resposta CriarPergunta(AppDbContext _context) {

            var pergunta = new Pergunta
            {
                Descricao = Descricao,
                QuizId = QuizId,
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
    }
}

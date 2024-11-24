using GETAF.Models.Context;
using GETAF.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace GETAF.Models.ViewModel
{
    public class QuizViewModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int GrupoId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }

        public Resposta CriarQuiz(AppDbContext _context)
        {
            try
            {
                var quiz = new Quiz
                {
                    Titulo = Titulo,
                    Descricao = Descricao,
                    UsuarioId = UsuarioId,
                    GrupoId = GrupoId
                };
                _context.Quiz.Add(quiz);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return new Resposta(false, "Algo deu errado ao tentar criar o quiz");
            }
            return new Resposta(true, "Quiz criado com sucesso!");

        }

        public List<Quiz> ListarQuiz(AppDbContext _context)
        {
            try
            {
                return _context.Quiz.Where(x => x.GrupoId == GrupoId).ToList();
            }
            catch (Exception)
            {
                return new List<Quiz>();
            }
        }

        public Resposta UpdateQuiz(AppDbContext _context)
        {
            try
            {
                var quiz = _context.Quiz.Find(Id);
                if (quiz == null) return null;

                quiz.Titulo = Titulo;
                quiz.Descricao = Descricao;
                quiz.UsuarioId = UsuarioId;
                quiz.GrupoId = GrupoId;

                _context.Quiz.Update(quiz);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return new Resposta(false, "Algo deu errado ao tentar editar o quiz");
            }
            return new Resposta(true, "Quiz editado com sucesso!");
        }

        public Resposta HabilitarQuizRespostas(AppDbContext _context) {
            try {
                var quiz = _context.Quiz.Find(Id);
                if (quiz == null) return null;

                quiz.IsAbertoResposta = true;

                _context.Quiz.Update(quiz);
                _context.SaveChanges();
            }
            catch (Exception ex) {
                return new Resposta(false, "Algo deu errado ao tentar editar o quiz");
            }
            return new Resposta(true, "Quiz editado com sucesso!");
        }


        public Resposta ExcluirQuiz(AppDbContext _context) {
            try {
                var quiz = _context.Quiz.Find(Id);
                if (quiz == null) throw new Exception();

                _context.Quiz.Remove(quiz);
                _context.SaveChanges();
            } catch  {
                return new Resposta(false, "Algo deu errado ao tentar excluir o quiz");
            }
            return new Resposta(true, "Quiz excluido com sucesso!");
        }
    }
}

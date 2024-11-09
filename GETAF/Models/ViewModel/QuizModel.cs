using GETAF.Models.Context;
using GETAF.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace GETAF.Models.ViewModel
{
    public class QuizModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int GrupoId { get; set; }
        [Required]
        public required string Titulo { get; set; }
        public string Descricao { get; set; }

        public Quiz? CriarQuiz(AppDbContext _context)
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
                return quiz;
            }
            catch (Exception ex)
            {

                return null;
            }
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

        public Quiz? UpdateQuiz(AppDbContext _context)
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
                return quiz;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Quiz? ExcluirQuiz(AppDbContext _context)
        {
            try
            {
                var quiz = _context.Quiz.Find(Id);
                if (quiz == null) return null;

                _context.Quiz.Remove(quiz);
                _context.SaveChanges();
                return quiz;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

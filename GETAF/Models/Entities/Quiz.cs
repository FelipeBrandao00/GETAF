using System.ComponentModel.DataAnnotations;

namespace GETAF.Models.Entities
{
    public class Quiz
    {
        [Key]
        public int Id { get; set; }
        public int IdTarefa { get; set; }
        public string Titulo { get; set; }

        public virtual Tarefa? Tarefa { get; set; }
        public virtual List<QuizUsuario>? QuizUsuarios { get; set; }
    }
}

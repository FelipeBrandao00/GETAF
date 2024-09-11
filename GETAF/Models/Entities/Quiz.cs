using System.ComponentModel.DataAnnotations;

namespace GETAF.Models.Entities
{
    public class Quiz
    {
        [Key]
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public int TarefaId { get; set; }
        public int UsuarioId { get; set; }

        public virtual Tarefa? Tarefa { get; set; }
        public virtual Usuario? Usuario { get; set; }
        public virtual List<QuizUsuario>? QuizUsuarios { get; set; }
    }
}

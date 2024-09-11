using System.ComponentModel.DataAnnotations;

namespace GETAF.Models.Entities
{
    public class Alternativa
    {
        [Key]
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public int QuizId { get; set; }

        public string Descricao { get; set; }

        public bool IsCorrect { get; set; }

        public virtual Quiz? Quiz { get; set; }
        public virtual Usuario? Usuario { get; set; }

    }
}

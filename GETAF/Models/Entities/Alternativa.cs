using System.ComponentModel.DataAnnotations;

namespace GETAF.Models.Entities
{
    public class Alternativa
    {
        [Key]
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public bool IsCorreta { get; set; }
        public int QuizId { get; set; }
        public virtual Quiz? Quiz { get; set; }
    }
}

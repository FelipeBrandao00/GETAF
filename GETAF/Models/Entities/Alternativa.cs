using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GETAF.Models.Entities {
    public class Alternativa {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PerguntaId { get; set; }
        public string? Descricao { get; set; }
        public bool IsCorreta { get; set; }
        public int QuizId { get; set; }
        public virtual Pergunta? Pergunta { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GETAF.Models.Entities;

public class Pergunta
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int QuizId { get; set; }
    public required string Descricao { get; set; }
    public virtual Quiz? Quiz { get; set; }
    public virtual List<Quiz> Quizzes { get; set; }
    public virtual List<Alternativa> Alternativas { get; set; }
}
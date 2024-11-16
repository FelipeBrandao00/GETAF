using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GETAF.Models.Entities;
public class Usuario {
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public required string Nome { get; set; }
    public required string Email { get; set; }
    public required string Senha { get; set; }
    public bool IsAtivo { get; set; }
    public byte[]? Foto { get; set; }
    public byte[]? Salt { get; set; }
    public virtual List<GrupoUsuario> GrupoUsuarios { get; set; }
    public virtual List<PerguntaUsuario>? RespostaUsuarios { get; set; }
    public virtual List<Quiz>? Quiz { get; set; }
    public virtual List<Tarefa> Tarefas { get; set; }
    public virtual List<Ranking> Ranking { get; set; }
}

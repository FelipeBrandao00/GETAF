using System.ComponentModel.DataAnnotations;

namespace GETAF.Models.Entities; 
public class Tarefa {
    [Key]
    public int Id { get; set; }
    public required string Nome { get; set; }
    public string? Descricao { get; set; }
    public bool IsCompleta { get; set; }
    public DateTime? DtInicio { get; set; }
    public DateTime? DtFim { get; set; }

    public int StatusId { get; set; }
    public int UsuarioId { get; set; }
    public int GrupoId { get; set; }

    public virtual Status? Status { get; set; }
    public virtual Usuario? Usuario { get; set; }
    public virtual Grupo? Grupo { get; set; }


}

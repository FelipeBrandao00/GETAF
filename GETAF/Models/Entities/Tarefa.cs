using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GETAF.Models.Entities;
public class Tarefa {
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public required string Nome { get; set; }
    public string? Descricao { get; set; }
    public DateTime? DtInicio { get; set; }
    public DateTime? DtFim { get; set; }
    public int? CdStatus { get; set; }

    public int UsuarioId { get; set; }
    public int GrupoId { get; set; }
    public int DificuldadeId { get; set; }

    public virtual Usuario? Usuario { get; set; }
    public virtual Grupo? Grupo { get; set; }
    public virtual Dificuldade? Dificuldade { get; set; }


}

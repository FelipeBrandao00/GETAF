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

    public int UsuarioId { get; set; }
    public int GrupoId { get; set; }
    public int MateriaId { get; set; }
    public int DificuldadeId { get; set; }

    public virtual Usuario? Usuario { get; set; }
    public virtual Grupo? Grupo { get; set; }
    public virtual Materia? Materia { get; set; }
    public virtual Dificuldade? Dificuldade { get; set; }


}

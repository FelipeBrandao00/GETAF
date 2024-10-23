using System.ComponentModel.DataAnnotations;

namespace GETAF.Models.Entities;
public class Grupo {
    [Key]
    public int Id { get; set; }
    public required string Nome { get; set; }
    public string? Descricao { get; set; }
    public int UsuarioId { get; set; }

    public virtual required Usuario Usuario { get; set; }
    public virtual List<GrupoUsuario> GrupoUsuarios { get; set; }

    public virtual List<Ranking> Ranking { get; set; }
}

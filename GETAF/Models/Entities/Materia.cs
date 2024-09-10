using System.ComponentModel.DataAnnotations;

namespace GETAF.Models.Entities; 
public class Materia {
    [Key]
    public int Id { get; set; }
    public required string Nome { get; set; }
}

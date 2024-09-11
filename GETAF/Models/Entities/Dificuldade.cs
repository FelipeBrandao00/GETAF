using System.ComponentModel.DataAnnotations;

namespace GETAF.Models.Entities;
public class Dificuldade {
    [Key]
    public int Id { get; set; }
    public required string Nivel { get; set; }
}

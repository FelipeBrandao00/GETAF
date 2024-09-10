using System.ComponentModel.DataAnnotations;

namespace GETAF.Models.Entities; 
public class Status {
    [Key]
    public int Id { get; set; }
    public required string Nome { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GETAF.Models.Entities {
    public class Quiz {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int GrupoId { get; set; }
        public required string Titulo { get; set; }
        public string Descricao { get; set; }
        
        public virtual Grupo? Grupo { get; set; }
        public virtual Usuario? Usuario { get; set; }
        public virtual List<Pergunta> Perguntas { get; set; }
        public virtual List<QuizUsuario>? QuizUsuarios { get; set; }
    }
}

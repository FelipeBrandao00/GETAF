namespace GETAF.Models.Entities {
    public class QuizUsuario {
        public int QuizId { get; set; }
        public int UsuarioId { get; set; }
        public int AlternativaId { get; set; }

        public virtual Usuario? Usuario { get; set; }
        public virtual Quiz? Quiz { get; set; }
        public virtual Alternativa? Alternativa { get; set; }
    }
}

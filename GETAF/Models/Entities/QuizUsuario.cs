namespace GETAF.Models.Entities {
    public class RespostaUsuario {
        public int PerguntaId { get; set; }
        public int UsuarioId { get; set; }
        public int AlternativaId { get; set; }

        public virtual Usuario? Usuario { get; set; }
        public virtual Pergunta? Pergunta { get; set; }
        public virtual Alternativa? Alternativa { get; set; }
    }
}

namespace GETAF.Models.Entities {
    public class GrupoUsuario {
        public int GrupoId { get; set; }
        public int UsuarioId { get; set; }

        public int UsuaProp { get; set; }

        public virtual Usuario? Usuario { get; set; }
        public virtual Grupo? Grupo { get; set; }
    }
}

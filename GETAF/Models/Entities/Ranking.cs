namespace GETAF.Models.Entities
{
    public class Ranking
    {
        public int GrupoId { get; set; }

        public int UsuarioId { get; set; }

        public int Pontos { get; set; }

        public virtual Grupo? Grupo { get; set; }

        public virtual Usuario? Usuario { get; set; }
    }
}

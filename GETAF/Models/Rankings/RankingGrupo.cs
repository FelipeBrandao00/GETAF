using GETAF.Models.Entities;

namespace GETAF.Models.Rankings
{
    public class RankingGrupo
    {
        public virtual GrupoUsuario GrupoUsuario { get; set; }
        public virtual int Pontos { get; set; }
    }
}

using GETAF.Migrations;
using GETAF.Models.Context;
using GETAF.Models.Entities;
using GETAF.Models.ViewModel;

namespace GETAF.Models.Rankings
{
    public class RankingAluno
    {
        public int GpId { get; set; }

        public int UsuaId { get; set; }

        public int Pontos {  get; set; }

    }
}

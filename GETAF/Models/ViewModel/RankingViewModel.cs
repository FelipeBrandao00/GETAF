using GETAF.Migrations;
using GETAF.Models.Context;
using GETAF.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace GETAF.Models.ViewModel
{
    public class RankingViewModel
    {
        public int GrupoId { get; set; }
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public int Pontos {  get; set; }
        public int? Rank { get; set; }
        public byte[] Foto { get; set; }

        public Resposta Pontuar(AppDbContext _context, int dificuldade) {
            try {
                var usuaPontuado = _context.GrupoUsuarios.FirstOrDefault(membro => membro.Usuario.Id == UsuarioId && membro.Grupo.Id == GrupoId);

                if (dificuldade == 1) //fácil
                {
                    Pontos += 1;

                }
                else
                {
                    if (dificuldade == 2) //medio
                    {
                        Pontos += 3;

                    }
                    else //dificil
                    {
                        Pontos += 6;
                    }
                }

               var pontuacao = new Entities.Ranking()
                {
                    GrupoId = GrupoId,
                    UsuarioId = UsuarioId,
                    Pontos = Pontos
                };

                _context.Ranking.Add(pontuacao);
                _context.SaveChanges();

                return new Resposta(true, "Pontos adiquiridos com sucesso!");
            }
            catch (Exception ex)
            {
                return new Resposta(false, "Erro ao calcular pontuação do usuário");
            }
        }

        public List<RankingViewModel> BuscarRanking(AppDbContext _context, int grupoId) {
            var lstRanking = _context.Ranking.Where(x => x.GrupoId == grupoId)
                .Include(x => x.Usuario)
                .OrderByDescending(x => x.Pontos)
                .Select(x => new RankingViewModel {
                    GrupoId = x.GrupoId,
                    Pontos = x.Pontos,
                    UsuarioId = x.UsuarioId,
                    Foto = x.Usuario.Foto,
                    Rank = null,
                    Nome = x.Usuario.Nome,
                })
                .ToList();

            int rank = 1;
            for (int i = 0; i < lstRanking.Count; i++) {
                if (i > 0 && lstRanking[i].Pontos != lstRanking[i - 1].Pontos) {
                    ++rank;
                }

                if (rank > 0 && rank < 4) {
                    lstRanking[i].Rank = rank;
                } else {
                    lstRanking[i].Rank = null;
                }
            }
            return lstRanking;
        }
    }
}

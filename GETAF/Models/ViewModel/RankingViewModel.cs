using GETAF.Migrations;
using GETAF.Models.Context;
using GETAF.Models.Entities;
using System;

namespace GETAF.Models.ViewModel
{
    public class RankingViewModel
    {
        public int GrupoId { get; set; }
        public int UsuarioId { get; set; }
        public int Pontos {  get; set; }
        public Resposta Pontuar(AppDbContext _context, int dificuldade)
        {
            try
            {
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
    }
}

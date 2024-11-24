using GETAF.Models.Context;
using GETAF.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace GETAF.Models.ViewModel {
    public class GrupoModel() {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; } = "";


        public Resposta CriarGrupo(AppDbContext _context,int userId) {
            try {
                var usuarioExistente = _context.Usuarios.Find(userId);
                var grupo = new Grupo()
                {
                    Nome = Nome,
                    Descricao = Descricao,
                    Usuario = usuarioExistente,
                    UsuarioId = usuarioExistente.Id,
                    IsAtivo = true,
                };

                _context.Grupos.Add(grupo);
                _context.SaveChanges();
                AssociarCriadorGrupo(_context, userId, grupo.Id);
            }
            catch (Exception) {
                return new Resposta(false, "Algo deu errado ao tentar criar o grupo");
            }

            return new Resposta(true, "Criado com sucesso!");
        }

        //public IActionResult DetalhesGrupo()
        //{
        //    return new Resposta(false, "");
        //}

        public Resposta EditarGrupo(AppDbContext _context)
        {
            try {
                var grupo = _context.Grupos.Find(Id);
                grupo.Nome = Nome;
                grupo.Descricao = Descricao;
                _context.SaveChanges();
                return new Resposta(true, "Sucesso ao editar grupo");
            }
            catch (Exception ex) {
                return new Resposta(false, "Erro ao editar grupo");
            }

        }

        public Resposta ExcluirGrupo(AppDbContext _context) {
            try {
                var grupo = _context.Grupos.Find(Id);
                grupo.IsAtivo = false;
                _context.SaveChanges();
                return new Resposta(true, "Sucesso ao excluir grupo");
            }
            catch (Exception ex) {
                return new Resposta(false, "Erro ao excluir grupo");
            }
        }

        public Resposta AssociarCriadorGrupo(AppDbContext _context, int userId, int grupoId)
        {
           try
            {
                var usuarioExistente = _context.Usuarios.Find(userId);
                var grupo = _context.Grupos.Find(grupoId);
                var GrupoUsua = new GrupoUsuario()
                {
                    GrupoId = grupoId,
                    UsuarioId = usuarioExistente.Id
                   // UsuaProp = 1
                };

                _context.GrupoUsuarios.Add(GrupoUsua);
                _context.SaveChanges();

                return new Resposta(true, "Sucesso ao vincular criador ao grupo");
            }
            catch (Exception ex)
            {
                return new Resposta(false, "Erro ao vincular criador ao grupo");
            }
        }


    }
}

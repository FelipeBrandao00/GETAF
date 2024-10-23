using GETAF.Models.Context;
using GETAF.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GETAF.Models.ViewModel
{
    public class GrupoUsuariosModel
    {
        public int GrupoId { get; set; }
        public int UsuarioId { get; set; }

        public Resposta AddMembro (AppDbContext _context, int userId, int grupoId)
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

                return new Resposta(true, "Sucesso ao vincular usuário ao grupo");
            }
            catch (Exception ex) 
            {
                return new Resposta(false, "Erro ao vincular usuário ao grupo");
            }
        }

        public Resposta ExcluirMembro(AppDbContext _context, int gpId, int usuarioId)
        {
            try
            {
                var gpUsua = _context.GrupoUsuarios.FirstOrDefault(
                    gu => gu.GrupoId == gpId && gu.UsuarioId == usuarioId);
                _context.GrupoUsuarios.Remove(gpUsua);
                _context.SaveChanges();
                return new Resposta(true, "Sucesso ao excluir membro do grupo!");
            }
            catch (Exception ex)
            {
                return new Resposta(false, "Erro ao excluir membro do grupo.");
            }
        }
    }
}

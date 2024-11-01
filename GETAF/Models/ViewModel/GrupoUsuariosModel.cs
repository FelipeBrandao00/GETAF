using Azure.Core;
using GETAF.Models.Context;
using GETAF.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GETAF.Models.ViewModel
{
    public class GrupoUsuariosModel
    {
        public int GrupoId { get; set; }
        public int UsuarioId { get; set; }
        public string? UsuarioEmail { get; set; }

        public Resposta AddMembro (AppDbContext _context)
        {
            try
            {
                var novoMembro = _context.Usuarios.FirstOrDefault(u => u.Email.ToLower() == UsuarioEmail.ToLower());

                if(novoMembro == null) return new Resposta(false, "Usuário não encontrado.");

                GrupoUsuario grupoUsuario = _context.GrupoUsuarios.FirstOrDefault(u => u.UsuarioId == novoMembro.Id && u.GrupoId == GrupoId);

                if(grupoUsuario != null) return new Resposta(false, "Usuário já vinculado a este grupo.");

                grupoUsuario = new GrupoUsuario()
                {
                    GrupoId = GrupoId,
                    UsuarioId = novoMembro.Id
                };

                _context.GrupoUsuarios.Add(grupoUsuario);
                _context.SaveChanges();

                return new Resposta(true, "Sucesso ao vincular usuário ao grupo");
            }
            catch (Exception ex) 
            {
                return new Resposta(false, "Erro ao vincular usuário ao grupo");
            }
        }

        public Resposta ExcluirMembro(AppDbContext _context)
        {
            try
            {
                var gpUsua = _context.GrupoUsuarios.FirstOrDefault(
                    gu => gu.GrupoId == GrupoId && gu.UsuarioId == UsuarioId);

                if (gpUsua == null) return new Resposta(false, "Usuário não encontrado.");

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

using GETAF.Models.Context;
using GETAF.Models.Entities;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace GETAF.Models.ViewModel
{
    public class ConfiguracaoModel
    {
        public string Nome { get; set; }
        public byte[]? Foto { get; set; }


        public Resposta EditarNome(Usuario usuario)
        {
            try
            {
                using (var _context = new AppDbContext())
                {
                    var user = _context.Usuarios.Where(x => x.Id == usuario.Id).FirstOrDefault();

                    user.Nome = Nome;

                    _context.Usuarios.Update(user);
                    _context.SaveChanges();

                    return new Resposta(true, "Nome Alterado com Sucesso");
                }
            }
            catch (Exception)
            {
                return new Resposta(false, "Erro ao editar o nome");
            }
        }

        public Resposta DeletarContaUsuario(Usuario usuario) {
            try {
                using (var _context = new AppDbContext()) {
                    var user = _context.Usuarios.Where(x => x.Id == usuario.Id).FirstOrDefault();

                    if(user == null)
                        return new Resposta(false, "Usuário não encontrado.");

                    user.IsAtivo = false;

                    var gruposUsuarioLider = _context.Grupos.Where(x => x.UsuarioId == user.Id).ToList();
                    if (gruposUsuarioLider.Any()) {
                        //ver se existem outros membros nos grupos
                        foreach (var grupo in gruposUsuarioLider) {
                            var qtMembros = _context.GrupoUsuarios.Where(x => x.GrupoId == grupo.Id && x.Usuario.IsAtivo == true)
                                .Include(x => x.Usuario)
                                .Count();
                            if (qtMembros > 1) {
                                //outro membro a não ser o líder
                                var outroMembro = _context.GrupoUsuarios.Where(x => x.GrupoId == grupo.Id && x.Usuario.IsAtivo == true
                                && x.UsuarioId != user.Id)
                                    .FirstOrDefault();

                                //novo lider
                                grupo.UsuarioId = outroMembro.UsuarioId;
                            } else {
                                //inativa o grupo
                                grupo.IsAtivo = false;
                            }
                        }
                    }

                    _context.SaveChanges();
                    return new Resposta(true, "Conta deletada com sucesso");
                }
            }
            catch (Exception) {
                return new Resposta(false, "Erro ao deletar a conta");
            }
        }

        //public async Resposta EditarFoto(IFormFile FotoPerfil)
        //{
        //    if (FotoPerfil != null && FotoPerfil.Length > 0)
        //    {
        //        var caminhoImagem = Path.Combine("caminho/para/salvar/imagens", FotoPerfil.FileName);

        //        using (var stream = new FileStream(caminhoImagem, FileMode.Create))
        //        {
        //            await FotoPerfil.CopyToAsync(stream);
        //        }
        //    }

        //    return null;
        //}

    }
}

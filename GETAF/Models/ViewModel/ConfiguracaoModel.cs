using GETAF.Models.Context;
using GETAF.Models.Entities;

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

        public Resposta DeletarContaUsuario(Usuario usuario)
        {
            try
            {
                using (var _context = new AppDbContext())
                {
                    var user = _context.Usuarios.Where(x => x.Id == usuario.Id).FirstOrDefault();

                    if(user == null)
                        return new Resposta(false, "Usuário não encontrado.");

                    _context.Usuarios.Remove(user);
                    _context.SaveChanges();

                    return new Resposta(true, "Conta deletada com sucesso");
                }
            }
            catch (Exception)
            {
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

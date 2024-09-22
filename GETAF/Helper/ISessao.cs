using GETAF.Models.Entities;

namespace GETAF.Helper
{
    public interface ISessao
    {
        void CriarSessaoUsuario(string chave, Usuario usuario);
        void RemoverSessaoUsuario(string chave);
        Usuario BuscarSessaoUsuario(string chave);
    }
}

using GETAF.Models.Context;
using GETAF.Models.Entities;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace GETAF.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContextAcessor;

        public Sessao(IHttpContextAccessor httpContextAcessor)
        {
            _httpContextAcessor = httpContextAcessor;
        }

        public void AtualizarSessaoUsuario(string chave)
        {
            var Sessaousuario = BuscarSessaoUsuario(chave);

            if (Sessaousuario == null)
            {
                throw new Exception("Usuário não encontrado na sessão.");
            }

            using (var context = new AppDbContext())
            {
                var usuarioAtualizado = context.Usuarios.FirstOrDefault(x => x.Id == Sessaousuario.Id);

                if (usuarioAtualizado != null)
                {
                    string valor = JsonConvert.SerializeObject(usuarioAtualizado);
                    _httpContextAcessor.HttpContext.Session.SetString(chave, valor);
                }
            }
        }

        public Usuario BuscarSessaoUsuario(string chave)
        {
            string SessaoUsuario = _httpContextAcessor.HttpContext.Session.GetString(chave);

            if (string.IsNullOrEmpty(SessaoUsuario)) return null;

            return JsonConvert.DeserializeObject<Usuario>(SessaoUsuario);
        }

        public void CriarSessaoUsuario(string chave, Usuario usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);
            _httpContextAcessor.HttpContext.Session.SetString(chave, valor);
        }

        public void RemoverSessaoUsuario(string chave)
        {
            _httpContextAcessor.HttpContext.Session.Remove(chave);
        }
    }
}

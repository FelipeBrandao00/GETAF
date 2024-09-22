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

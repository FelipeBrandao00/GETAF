using GETAF.Models.Entities;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace GETAF.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public Usuario BuscarSessaoUsuario()
        {
            string SessaoUsuario = _httpContext.HttpContext.Session.GetString("SessaoUsuarioLogado");

            if (string.IsNullOrEmpty(SessaoUsuario)) return null;

            return JsonConvert.DeserializeObject<Usuario>(SessaoUsuario);
        }

        public void CriarSessaoUsuario(Usuario usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);
            _httpContext.HttpContext.Session.SetString("SessaoUsuarioLogado", valor);
        }

        public void RemoverSessaoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("SessaoUsuarioLogado");
        }
    }
}

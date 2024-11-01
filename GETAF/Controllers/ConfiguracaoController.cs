using GETAF.Helper;
using GETAF.Models;
using GETAF.Models.Context;
using GETAF.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GETAF.Controllers
{
    public class ConfiguracaoController : Controller
    {
        private readonly string _caminhoImagens;
        private readonly ISessao _sessao;
        public ConfiguracaoController(ISessao sessao, IWebHostEnvironment ambiente)
        {
            _sessao = sessao;
            _caminhoImagens = Path.Combine(ambiente.WebRootPath, "Imagens");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DeletarConta()
        {
            return View();
        }

        public JsonResult EditarNome([FromBody] ConfiguracaoModel config)
        {
            var usuario = _sessao.BuscarSessaoUsuario("SessaoUsuarioLogado");
            var resposta = config.EditarNome(usuario);

            if (resposta.Sucesso)
                _sessao.AtualizarSessaoUsuario("SessaoUsuarioLogado");

            return Json(new { sucesso = resposta.Sucesso, mensagem = resposta.Mensagem });
        }

        public JsonResult DeletarContaUsuario()
        {
            var config = new ConfiguracaoModel();
            var usuario = _sessao.BuscarSessaoUsuario("SessaoUsuarioLogado");
            var resposta = config.DeletarContaUsuario(usuario);

            if (resposta.Sucesso)
            {
                _sessao.RemoverSessaoUsuario("SessaoUsuarioLogado");
            }

            return Json(new { sucesso = resposta.Sucesso, mensagem = resposta.Mensagem });
        }

        [HttpPost]
        public async Task<IActionResult> UploadImagem(IFormFile foto)
        {
            if (foto == null || foto.Length == 0)
            {
                return Json(new { sucesso = false, mensagem = "Nenhuma imagem foi enviada." });
            }
            if (!Directory.Exists(_caminhoImagens))
            {
                Directory.CreateDirectory(_caminhoImagens);
            }
            using (var memoryStream = new MemoryStream())
            {
                await foto.CopyToAsync(memoryStream);
                var fotoBytes = memoryStream.ToArray();
                var usuario = _sessao.BuscarSessaoUsuario("SessaoUsuarioLogado");
                usuario.Foto = fotoBytes;
                using (var context = new AppDbContext())
                {
                    context.Usuarios.Update(usuario);
                    await context.SaveChangesAsync();
                }
                _sessao.AtualizarSessaoUsuario("SessaoUsuarioLogado");
                return Json(new { sucesso = true, mensagem = "Imagem carregada com sucesso!" });
            }
        }
        public IActionResult GetUserImage()
        {
            var usuario = _sessao.BuscarSessaoUsuario("SessaoUsuarioLogado");
            if (usuario != null && usuario.Foto != null)
            {
                return File(usuario.Foto, "image/png"); // Retorne no tipo de imagem correta
            }

            return File("/Imagens/default.png", "image/png"); // Imagem padrão se o usuário não tiver uma imagem
        }
    }
}
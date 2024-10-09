using GETAF.Helper;
using GETAF.Models.Context;
using GETAF.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GETAF.Models.ViewModel
{
    public class ConvidarParaGrupoModel
    {
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; }

        public (Usuario usuario, Resposta resposta ) EnviarEmail()
        {
            try
            {
                using (var _context = new AppDbContext())
                {
                    var user = _context.Usuarios.Where(x => x.Email == Email).FirstOrDefault();
                    if (user == null)
                    {
                        return (null, new Resposta(false, "Email inválido"));
                    }
                    return (user, new Resposta(true, "Código Enviado"));
                }
            }
            catch (Exception ex)
            {
                return (null, new Resposta(false, "Erro ao enviar o email"));
            }
        }
      
    }
}

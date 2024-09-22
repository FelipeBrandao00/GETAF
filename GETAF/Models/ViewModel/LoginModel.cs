using GETAF.Models.Context;
using Microsoft.AspNetCore.Mvc;
using GETAF.Models;
using GETAF.Helper;
using GETAF.Models.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GETAF.Models.ViewModel {
    public class LoginModel {

        public string Email { get; set; }
        public string Password { get; set; }

        //Uma tupla é uma estrutura que pode armazenar múltiplos valores de diferentes tipos em uma única unidade. Em vez de retornar apenas um único valor
        //o método pode retornar ambos em uma única linha.
        public (Usuario usuario, Resposta resposta) ValidarLogin() {
            try {
                using (var _context = new AppDbContext()) {
                    var user = _context.Usuarios.Where(x => x.Email == Email).FirstOrDefault();
                    if (user == null) {
                        return (null, new Resposta(false, "Login/senha inválidos."));
                    }

                    if (Hash.ValidarHash(Password, user.Salt, user.Senha)) 
                    {
                        return (user, new Resposta(true, "Login bem-sucedido."));
                    }
                    return (null, new Resposta(false, "Login/senha inválidos."));
                }
            } catch (Exception ex) {
                return (null, new Resposta(false, ex.Message));
            }
        }
    }
}

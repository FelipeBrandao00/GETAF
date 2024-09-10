using GETAF.Models.Context;

namespace GETAF.Models.ViewModel.Login
{
    public class LoginModel {
        public string Email { get; set; }
        public string Password { get; set; }

        public Resposta ValidarLogin(){
            try {
                using (var _context = new Context.AppDbContext()) {
                    var icExiste = _context.Usuarios.Where(x => x.Email == Email && x.Senha == Password).Any();
                    if (icExiste) {
                        return new Resposta();
                    }
                    return new Resposta(false, "Login/senha inválidos.");
                }
            } catch (Exception ex) {
                return new Resposta(false, ex.Message);
            }
        }
    }
}

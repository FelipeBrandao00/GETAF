using GETAF.Models.Context;

namespace GETAF.Models.ViewModel
{
    public class CadastroModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Resposta Cadastrar()
        {
            try
            {

                using (var _context = new AppDbContext())
                {

                    var user = _context.Usuarios.Where(x => x.Email == Email).FirstOrDefault();
                    if (user != null)
                    {
                        return new Resposta(false, "Usuário já Cadastrado");
                    }

                    var hash = Hash.GerarHashSalt(Password, out byte[] salt);

                    _context.Usuarios.Add(
                   new Models.Entities.Usuario
                   {
                       Nome = Name,
                       Email = Email,
                       Senha = hash,
                       IsAtivo = true,
                       Foto = null,
                       Salt = salt
                   });

                    _context.SaveChanges();

                    return new Resposta();

                }

            }
            catch (Exception ex)
            {
                return new Resposta(false, ex.Message);
            }

        }
    }
}

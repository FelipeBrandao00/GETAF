using GETAF.Models.Context;

namespace GETAF.Models.ViewModel
{
    public class ConfiguracaoModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[]? Foto { get; set; }


        public Resposta EditarNome()
        {
            return null;
        }

        public Resposta EditarEmail()
        {
            return null;
        }

        public Resposta EditarPassword()
        {
            return null;
        }

        public Resposta EditarFoto()
        {
            return null;
        }

    }
}

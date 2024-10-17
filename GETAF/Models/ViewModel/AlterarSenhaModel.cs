
using GETAF.Models.Context;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace GETAF.Models.ViewModel
{
    public class AlterarSenhaModel
    {
        public string NovaSenha {  get; set; }
        public string ConfirmarSenha { get; set; }

        public Resposta RedefinirSenha(string email)
        {
            if(NovaSenha != ConfirmarSenha)
            {
                return new Resposta(false, "As senha nao coincidem");
            }

            try
            {
                using (var _context = new AppDbContext())
                {
                    var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email);
                    var hash = Hash.GerarHashSalt(ConfirmarSenha, out byte[] salt);

                    usuario.Senha = hash;
                    usuario.Salt = salt;

                    _context.Usuarios.Update(usuario);
                    _context.SaveChanges();
                    

                    return new Resposta(true, "Senha Alterada com sucesso");
                }
            }
            catch (Exception ex)
            {
                return new Resposta(false, ex.Message);
            }    
            
        }
    }
}

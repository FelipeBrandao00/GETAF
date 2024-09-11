using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace GETAF.Models {
    public class Hash {
        const int size = 64;
        const int iterations = 350000;

        public static string GerarHashSalt(string senha, out byte[] salt) {
            salt = RandomNumberGenerator.GetBytes(size);
            return GerarHash(senha, salt);
        }

        public static string GerarHash(string senha, byte[]? salt) {
            string hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                senha,
                salt,
                KeyDerivationPrf.HMACSHA256,
                iterations,
                size));

            return hash;
        }

        public static bool ValidarHash(string senha, byte[]? salt, string senhaGuardada) {
            return senhaGuardada == GerarHash(senha, salt);
        }
    }
}

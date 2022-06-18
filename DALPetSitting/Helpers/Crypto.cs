using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace DALPetSitting.Helpers
{
    public static class Crypto
    {
        /// <summary>
        /// Génère la clé de salage qui sera ajoutée au mdp 
        /// avant d'entré dans la fonction de hachage.
        /// Ces nbr aléatoires sont enregistrés dans un tableau de byte.
        /// </summary>
        /// <returns></returns>
        public static byte[] GenerateSalt()
        {

            byte[] salt = new byte[128/8];

            using(RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
            

            return  salt;
        }
        /// <summary>
        /// Hash le mdp apd de la clé de salage
        /// Algorithme utilisé : PBKDF2 => slow design
        /// Justification : l'algo est lent, par comnséquent l'attaquant prendra du temps pour réaliser la brute-force.
        /// Cela permet de réduire le nombre d'essaie/minutes d'attaque.
        /// </summary>
        /// <param name="salt"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string HashPassword(byte[] salt , string password)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password:password,
                salt:salt,
                prf:KeyDerivationPrf.HMACSHA512,
                iterationCount:100000,//param. garantissant le caractère "lent" du design
                numBytesRequested:512/8
                ));

            return hashed;
        }

    }
}

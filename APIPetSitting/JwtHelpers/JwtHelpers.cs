using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using APIPetSitting.Models;
using System.Collections.Generic;
using System;
using System.Text;

namespace APIPetSitting.JwtHelpers
{
    /// <summary>
    /// Créer, met à jour et valide le Token
    /// </summary>
    public static class JwtHelpers
    {
        /// <summary>
        /// Récupère les paires nom-valeur (claim) permettant d'identifier un utilisateur.
        /// Une claim est une paire clé-valeur fournie par l'utilisateur 
        /// utilisée pour générer un Token
        /// </summary>
        /// <param name="userAccounts"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, Guid Id)
        {
            IEnumerable<Claim> claims = new Claim[] {
                    new Claim("Id", userAccounts.GuidId.ToString()),
                    new Claim(ClaimTypes.Name, userAccounts.FirstName),
                    new Claim(ClaimTypes.Email, userAccounts.Email),
                    new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddDays(1).ToString("MMM ddd dd yyyy HH:mm:ss tt"))//token de durée illimité - mode dévelopement
            };
            return claims;
        }

        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, out Guid Id)
        {
            Id = Guid.NewGuid();// génère un GUID aléatoire garantissant que le token fournit est tjrs !=
            return GetClaims(userAccounts, Id);
        }
        /// <summary>
        /// Génère un Token pour un utilisateur sur base de sa "claim" respective
        /// </summary>
        /// <param name="model"></param>
        /// <param name="jwtSettings"></param>
        /// <returns></returns>
        public static UserTokens GenTokenkey(UserTokens model, JwtSettings jwtSettings)
        {
            try
            {
                UserTokens UserToken = new UserTokens();
                if (model == null) throw new ArgumentException(nameof(model));

                // Créer un tableau d'octets de clé secrète fournies dans appsettings.json
                byte[] key = Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey);
                Guid Id = Guid.Empty;
                DateTime expireTime = DateTime.UtcNow.AddDays(1);

                // Récupération des clés spécifiés dans appsettings.json + définition de la date d'exp.
                UserToken.Validaty = expireTime.TimeOfDay;

                JwtSecurityToken JWToken = new JwtSecurityToken
                    (
                        issuer: jwtSettings.ValidIssuer, 
                        audience: jwtSettings.ValidAudience, 
                        claims: GetClaims(model, out Id), 
                        notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                        expires: new DateTimeOffset(expireTime).DateTime,
                        signingCredentials: new SigningCredentials
                        (
                            new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256
                        )
                    );

                // Assignation du token à l'utilisateur
                UserToken.Token = new JwtSecurityTokenHandler().WriteToken(JWToken);
                UserToken.FirstName = model.FirstName;
                UserToken.Email = model.Email;
                //UserToken.RefreshToken = model.RefreshToken;

                return UserToken;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

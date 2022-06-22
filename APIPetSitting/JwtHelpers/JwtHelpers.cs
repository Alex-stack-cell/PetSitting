using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Collections.Generic;
using System;
using System.Text;
using APIPetSitting.Models.Concretes.Auth;

namespace APIPetSitting.JwtHelpers
{
    /// <summary>
    /// Créer, met à jour et valide le Token
    /// </summary>
    public static class JwtHelpers
    {
        /// <summary>
        /// Récupère les paires nom-valeur (claim) permettant d'identifier un utilisateur.
        /// Une claim est une paire clé-valeur, dont la valeur est renseignée par l'utilisateur 
        /// pour générer un Token
        /// </summary>
        /// <param name="userAccounts"></param>
        /// <returns></returns>
        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts)
        {
            IEnumerable<Claim> claims = new Claim[] {
                    new Claim("Id", userAccounts.Id.ToString(),ClaimValueTypes.Integer64),
                    new Claim("Username", userAccounts.FirstName),
                    new Claim("Owner", userAccounts.isOwner.ToString(), ClaimValueTypes.Boolean),
                    //new Claim(ClaimTypes.Email, userAccounts.Email),
                    new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddDays(1).ToString(),ClaimValueTypes.DateTime)//token de durée d'1 jour - mode dévelopement
            };
            return claims;
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

                // Récupération des clés spécifiés dans appsettings.json
                //UserToken.Validaty = expireTime.TimeOfDay;

                JwtSecurityToken JWToken = new JwtSecurityToken
                    (
                        issuer: jwtSettings.ValidIssuer, 
                        audience: jwtSettings.ValidAudience, 
                        claims: GetClaims(model), 
                        notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                        expires: new DateTimeOffset(expireTime).DateTime,
                        signingCredentials: new SigningCredentials
                        (
                            new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256
                        )
                    );

                // Assignation du token à l'utilisateur
                UserToken.Token = new JwtSecurityTokenHandler().WriteToken(JWToken);
                //UserToken.Email = model.Email;
                UserToken.isOwner =  model.isOwner;
                UserToken.Id = model.Id;

                return UserToken;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

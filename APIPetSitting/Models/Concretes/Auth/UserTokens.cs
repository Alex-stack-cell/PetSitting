using System;

namespace APIPetSitting.Models.Concretes.Auth
{
    /// <summary>
    /// Modèle du Token
    /// </summary>
    public class UserTokens
    {
        public string Token { get; set; }
        public bool isOwner { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
    }
}

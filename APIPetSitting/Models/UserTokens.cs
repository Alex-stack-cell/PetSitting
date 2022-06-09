using System;

namespace APIPetSitting.Models
{
    /// <summary>
    /// Modèle du Token
    /// </summary>
    public class UserTokens
    {
        public string Token{get;set;}
        public string FirstName { get;set;}
        public TimeSpan Validaty{get;set;}
        public string RefreshToken{get;set;}
        public string Email{get;set;}
        public Guid GuidId{get;set;}
        public DateTime ExpiredTime{ get;set;}
    }
}

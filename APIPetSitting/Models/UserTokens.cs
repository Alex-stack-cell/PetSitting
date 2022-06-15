using System;

namespace APIPetSitting.Models
{
    /// <summary>
    /// Modèle du Token
    /// </summary>
    public class UserTokens
    {
        public string Token{get;set;}
        public bool isOwner { get;set;}
        //public string RefreshToken{get;set;} //inactif en dév
        public string Email { get; set; }
        public int Id { get;set;}
        public string FirstName { get; set; }
        //public DateTime ExpiredTime{ get;set;}//inactif en dév
    }
}

using System.ComponentModel.DataAnnotations;

namespace APIPetSitting.Models
{
    public class UserLogins
    {
        [Required]
        public string UserEmail{get;set;}
        [Required]
        public string Password {get;set;}
        //public UserLogins() { }
    }
}

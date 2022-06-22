namespace BLLPetSitting.Concretes.Auth
{
    /// <summary>
    /// Information permettant de valier l'existance ou non du compte
    /// </summary>
    public class Account
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Passwd { get; set; }
    }
}

namespace APIPetSitting.Models.Abstracts.Users.Update.Info
{
    /// <summary>
    /// Propriété mises à jour pour un user
    /// </summary>
    public abstract class UserUpdateInfo
    {
        public int? Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
    }
}

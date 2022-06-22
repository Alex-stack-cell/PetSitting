using Microsoft.AspNetCore.Authorization;

namespace APIPetSitting.Requirements
{
    /// <summary>
    /// Classe travaillant en tandem avec GrantingActionHandler
    /// </summary>
    public class ActionGranted : IAuthorizationRequirement
    {
        public ActionGranted(int id)
        {
            this.Id = id;
        }

        protected int Id { get; set; }
    }
}

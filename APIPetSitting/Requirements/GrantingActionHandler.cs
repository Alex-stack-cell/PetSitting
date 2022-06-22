using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace APIPetSitting.Requirements
{
    /// <summary>
    /// Méthode permettant d'accorder l'authorisation pour une action précise, à un utilisateur sur base de son ID (claim).
    /// Cette méthode est une alternative à la méthode d'extension (ClaimsPrincipalExtension) et VerifyIdAttribute
    /// Cette approche repose sur les policy de Microsoft
    /// Non finie.
    /// </summary>
    public class GrantingActionHandler : AuthorizationHandler<ActionGranted>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ActionGranted requirement)
        {
            if (!context.User.HasClaim(c => c.Value.Equals("Id")))
            {
                return Task.FromResult(false);
            }
            throw new System.NotImplementedException();
        }
    }
}

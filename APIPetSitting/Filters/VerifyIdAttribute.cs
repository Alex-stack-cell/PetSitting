using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace APIPetSitting.Filters
{
    /// <summary>
    /// Méthode permettant de fournir l'authorisation d'une action à un utilisateur sur base de son Id (claim)
    /// </summary>
    public class VerifyIdAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string id = context.HttpContext.User.FindFirst("Id")?.Value;
            string contentId = context.RouteData.Values["Id"].ToString();

            if (id!=contentId)
            {
                context.Result = new UnauthorizedResult();
            }

            //throw new NotImplementedException();
        }
    }
}

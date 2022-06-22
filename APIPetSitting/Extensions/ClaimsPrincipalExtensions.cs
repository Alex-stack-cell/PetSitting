using System.Security.Claims;

namespace APIPetSitting.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetId(this ClaimsPrincipal user)
        {
            string claim = user.FindFirstValue("Id");
            if(claim != null)
            {
                return int.Parse(claim);
            }
            return -1;
        }
    }
}

using Microsoft.AspNetCore.Http;

namespace KPMG.ComplianceMonitor.Infra.CrossCutting.Identity.Authorization;

public static class CustomAuthorizationValidation
{
    public static bool UserHasValidClaim(HttpContext context, params string[] roleName)
    {
        return context.User.Identity.IsAuthenticated &&
               roleName.Any(x => context.User.IsInRole(x));
    }

}
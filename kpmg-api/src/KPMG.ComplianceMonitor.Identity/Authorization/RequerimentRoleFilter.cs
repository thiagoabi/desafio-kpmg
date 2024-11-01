using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace KPMG.ComplianceMonitor.Infra.CrossCutting.Identity.Authorization;

internal class RequerimentRoleFilter : IAuthorizationFilter
{
    private readonly string _roleName;

    public RequerimentRoleFilter(string roleName)
    {
        _roleName = roleName;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (!context.HttpContext.User.Identity.IsAuthenticated)
        {
            context.Result = new StatusCodeResult(401);
            return;
        }

        if (!CustomAuthorizationValidation.UserHasValidClaim(context.HttpContext, _roleName))
        {
            context.Result = new StatusCodeResult(403);
        }
    }
}
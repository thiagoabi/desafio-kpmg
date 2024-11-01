using Microsoft.AspNetCore.Mvc;

namespace KPMG.ComplianceMonitor.Infra.CrossCutting.Identity.Authorization;

public class CustomAuthorizeAttribute : TypeFilterAttribute
{
    public CustomAuthorizeAttribute(params string[] roleName) : base(typeof(RequerimentRoleFilter))
    {
        Arguments = roleName;
    }
}
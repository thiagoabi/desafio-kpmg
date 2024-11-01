using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace KPMG.ComplianceMonitor.Infra.CrossCutting.Identity.Users;

public interface IAspNetUser
{
    string Name { get; }
    Guid GetUserName();
    string GetUserEmail();
    bool IsAutenticated();
    bool IsInRole(string role);
    IEnumerable<Claim> GetUserClaims();
    HttpContext GetHttpContext();
}
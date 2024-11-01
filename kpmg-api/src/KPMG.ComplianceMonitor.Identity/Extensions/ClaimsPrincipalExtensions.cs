using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace KPMG.ComplianceMonitor.Infra.CrossCutting.Identity.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static string GetUserName(this ClaimsPrincipal principal)
    {
        if (principal == null)
        {
            throw new ArgumentException(nameof(principal));
        }

        var claim = principal.FindFirst(JwtRegisteredClaimNames.Sub);
        if (claim is null)
            claim = principal.FindFirst(ClaimTypes.NameIdentifier);

        return claim?.Value;
    }

    public static string GetUserEmail(this ClaimsPrincipal principal)
    {
        if (principal == null)
        {
            throw new ArgumentException(nameof(principal));
        }
        var claim = principal.FindFirst(JwtRegisteredClaimNames.Sub);
        if (claim is null)
            claim = principal.FindFirst(ClaimTypes.Email);

        return claim?.Value;
    }
    public static string GetUserName(this ClaimsIdentity principal)
    {
        if (principal == null)
        {
            throw new ArgumentException(nameof(principal));
        }

        var claim = principal.FindFirst(JwtRegisteredClaimNames.Sub);
        if (claim is null)
            claim = principal.FindFirst(ClaimTypes.NameIdentifier);

        return claim?.Value;
    }

    public static string GetUserEmail(this ClaimsIdentity principal)
    {
        if (principal == null)
        {
            throw new ArgumentException(nameof(principal));
        }
        var claim = principal.FindFirst(JwtRegisteredClaimNames.Sub);
        if (claim is null)
            claim = principal.FindFirst(ClaimTypes.Email);

        return claim?.Value;
    }
}
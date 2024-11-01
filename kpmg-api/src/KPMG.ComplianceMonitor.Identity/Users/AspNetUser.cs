﻿using System.Security.Claims;
using KPMG.ComplianceMonitor.Infra.CrossCutting.Identity.Extensions;
using Microsoft.AspNetCore.Http;

namespace KPMG.ComplianceMonitor.Infra.CrossCutting.Identity.Users;

public class AspNetUser : IAspNetUser
{
    private readonly IHttpContextAccessor _accessor;

    public AspNetUser(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }

    public string Name => _accessor.HttpContext.User.Identity.Name;

    public Guid GetUserName()
    {
        return IsAutenticated() ? Guid.Parse(_accessor.HttpContext.User.GetUserName()) : Guid.Empty;
    }

    public string GetUserEmail()
    {
        return IsAutenticated() ? _accessor.HttpContext.User.GetUserEmail() : "";
    }

    public bool IsAutenticated()
    {
        return _accessor.HttpContext.User.Identity.IsAuthenticated;
    }

    public bool IsInRole(string role)
    {
        return _accessor.HttpContext.User.IsInRole(role);
    }

    public IEnumerable<Claim> GetUserClaims()
    {
        return _accessor.HttpContext.User.Claims;
    }

    public HttpContext GetHttpContext()
    {
        return _accessor.HttpContext;
    }
}
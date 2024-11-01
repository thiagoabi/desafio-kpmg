using KPMG.ComplianceMonitor.Api.Controllers.Base;
using KPMG.ComplianceMonitor.Infra.CrossCutting.Identity.API;
using KPMG.ComplianceMonitor.Infra.CrossCutting.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace KPMG.ComplianceMonitor.Api.Controllers;

[Route("account")]
[ApiController]
public class AccountController : CustomControllerBase
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly AppJwtSettings _appJwtSettings;

    public AccountController(
        SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager,
        IOptions<AppJwtSettings> appJwtSettings)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _appJwtSettings = appJwtSettings.Value;
    }

    [HttpPost]
    [Route("create")]
    public async Task<ActionResult> Register(RegisterUser registerUser)
    {
        if (!ModelState.IsValid) return CustomResponse(StatusCodes.Status400BadRequest, ModelState);

        var user = new IdentityUser
        {
            UserName = registerUser.Email,
            Email = registerUser.Email,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, registerUser.Password);

        if (result.Succeeded)
        {
            return CustomResponse(StatusCodes.Status400BadRequest, GetFullJwt(user.Email));
        }

        foreach (var error in result.Errors)
        {
            AddError(error.Description);
        }

        return CustomResponse();
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginUser loginUser)
    {
        if (!ModelState.IsValid) return CustomResponse(StatusCodes.Status400BadRequest, ModelState);

        var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

        if (result.Succeeded)
        {
            var fullJwt = GetFullJwt(loginUser.Email);
            return CustomResponse(StatusCodes.Status200OK, fullJwt);
        }

        if (result.IsLockedOut)
        {
            AddError("Este usuário está temporariamente bloqueado");
            return CustomResponse(StatusCodes.Status400BadRequest);
        }

        AddError("Usuário ou senha incorretos");
        return CustomResponse(StatusCodes.Status400BadRequest);
    }

    private string GetFullJwt(string email)
    {
        return new JwtBuilder()
            .WithUserManager(_userManager)
            .WithJwtSettings(_appJwtSettings)
            .WithEmail(email)
            .WithJwtClaims()
            .WithUserClaims()
            .WithUserRoles()
            .BuildToken();
    }
}

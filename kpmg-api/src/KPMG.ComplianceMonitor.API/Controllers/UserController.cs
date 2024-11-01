using AutoMapper;
using KPMG.ComplianceMonitor.Api.Controllers.Base;
using KPMG.ComplianceMonitor.Application.Dtos.Users.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KPMG.ComplianceMonitor.API.Controllers;

//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UsersController : CustomControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IMapper _mapper;

    public UsersController(UserManager<IdentityUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    //[CustomAuthorize("ComplianceChecks", "Write")]
    [HttpGet()]
    [ProducesResponseType<IEnumerable<ComplianceCheckResponseDto>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IEnumerable<UserResponseDto> GetAsync()
    {
        return _mapper.Map<IEnumerable<UserResponseDto>>(_userManager.Users);
    }
}

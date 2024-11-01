using KPMG.ComplianceMonitor.Api.Controllers.Base;
using KPMG.ComplianceMonitor.Application.Dtos.ComplianceChecks.Requests;
using KPMG.ComplianceMonitor.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KPMG.ComplianceMonitor.Api.Controllers;

[Route("api/compliance-checks")]
public class ComplianceCheckController : CustomControllerBase
{
    private readonly IComplianceCheckAppService _ComplianceCheckAppService;

    public ComplianceCheckController(IComplianceCheckAppService ComplianceCheckAppService)
    {
        _ComplianceCheckAppService = ComplianceCheckAppService;
    }

    //    [CustomAuthorize("ComplianceChecks", "Write")]
    [HttpGet()]
    [ProducesResponseType<IEnumerable<ComplianceCheckResponseDto>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAsync()
    {
        var result = await _ComplianceCheckAppService.GetAllAsync();

        return result == null ? NoContent() : Ok(result);
    }

    //   [CustomAuthorize("Admin")]
    [AllowAnonymous]
    [HttpGet("{id:guid}")]
    [ProducesResponseType<ComplianceCheckResponseDto>(StatusCodes.Status200OK)]
    [ProducesResponseType<ComplianceCheckResponseDto>(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAsync(Guid id)
    {
        var result = await _ComplianceCheckAppService.GetByIdAsync(id);

        return result == null ? NotFound() : Ok(result);
    }

    //[CustomAuthorize("Admin")]
    [HttpPost()]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PostCreateAsync([FromBody] ComplianceCheckCreateRequestDto request)
    {
        return !ModelState.IsValid ? CustomResponse(StatusCodes.Status400BadRequest, ModelState) : CustomResponse(StatusCodes.Status204NoContent, await _ComplianceCheckAppService.CreateAsync(request));
    }

    // [CustomAuthorize("Admin")]
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PutUpdateAsync([FromRoute] Guid id, [FromBody] ComplianceCheckUpdateRequestDto request)
    {
        return !ModelState.IsValid ? CustomResponse(StatusCodes.Status400BadRequest, ModelState) : CustomResponse(StatusCodes.Status204NoContent, await _ComplianceCheckAppService.UpdateAsync(id, request));
    }

    //[CustomAuthorize("Admin")]
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        return CustomResponse(StatusCodes.Status204NoContent, await _ComplianceCheckAppService.DeleteAsync(id)) ;
    }
}

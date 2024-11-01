using KPMG.ComplianceMonitor.Api.Controllers.Base;
using KPMG.ComplianceMonitor.Application.Dtos.RiskAssessments.Requests;
using KPMG.ComplianceMonitor.Application.Dtos.RiskAssessments.Responses;
using KPMG.ComplianceMonitor.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KPMG.ComplianceMonitor.Api.Controllers;

[Route("api/risk-assessments")]
public class RiskAssessmentController : CustomControllerBase
{
    private readonly IRiskAssessmentAppService _RiskAssessmentAppService;

    public RiskAssessmentController(IRiskAssessmentAppService RiskAssessmentAppService)
    {
        _RiskAssessmentAppService = RiskAssessmentAppService;
    }

    //    [CustomAuthorize("RiskAssessments", "Write")]
    [HttpGet()]
    [ProducesResponseType<IEnumerable<RiskAssessmentResponseDto>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAsync()
    {
        var result = await _RiskAssessmentAppService.GetAllAsync();

        return result == null ? NoContent() : Ok(result);
    }

    //   [CustomAuthorize("Admin")]
    [AllowAnonymous]
    [HttpGet("{id:guid}")]
    [ProducesResponseType<RiskAssessmentResponseDto>(StatusCodes.Status200OK)]
    [ProducesResponseType<RiskAssessmentResponseDto>(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAsync(Guid id)
    {
        var result = await _RiskAssessmentAppService.GetByIdAsync(id);

        return result == null ? NotFound() : Ok(result);
    }

    //[CustomAuthorize("Admin")]
    [HttpPost()]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PostCreateAsync([FromBody] RiskAssessmentCreateRequestDto request)
    {
        return !ModelState.IsValid ? CustomResponse(StatusCodes.Status400BadRequest, ModelState) : CustomResponse(StatusCodes.Status204NoContent, await _RiskAssessmentAppService.CreateAsync(request));
    }

    // [CustomAuthorize("Admin")]
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PutUpdateAsync([FromRoute] Guid id, [FromBody] RiskAssessmentUpdateRequestDto request)
    {
        return !ModelState.IsValid ? CustomResponse(StatusCodes.Status400BadRequest, ModelState) : CustomResponse(StatusCodes.Status204NoContent, await _RiskAssessmentAppService.UpdateAsync(id, request));
    }

    //[CustomAuthorize("Admin")]
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        return CustomResponse(StatusCodes.Status204NoContent, await _RiskAssessmentAppService.DeleteAsync(id)) ;
    }
}

using KPMG.ComplianceMonitor.Api.Controllers.Base;
using KPMG.ComplianceMonitor.Application.Dtos.Iincidents.Requests;
using KPMG.ComplianceMonitor.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KPMG.ComplianceMonitor.Api.Controllers
{
    public class IncidentsController : CustomControllerBase
    {
        private readonly IIncidentAppService _incidentAppService;

        public IncidentsController(IIncidentAppService incidentAppService)
        {
            _incidentAppService = incidentAppService;
        }

        //    [CustomAuthorize("Incidents", "Write")]
        [HttpGet()]
        [ProducesResponseType<IEnumerable<IncidentResponseDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _incidentAppService.GetAllAsync();

            return result == null ? NoContent() : Ok(result);
        }

        //   [CustomAuthorize("Admin")]
        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        [ProducesResponseType<IncidentResponseDto>(StatusCodes.Status200OK)]
        [ProducesResponseType<IncidentResponseDto>(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await _incidentAppService.GetByIdAsync(id);

            return result == null ? NotFound() : Ok(result);
        }

        //[CustomAuthorize("Admin")]
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostCreateAsync([FromBody] IncidentCreateRequestDto request)
        {
            return !ModelState.IsValid ? CustomResponse(StatusCodes.Status400BadRequest, ModelState) : CustomResponse(StatusCodes.Status204NoContent, await _incidentAppService.CreateAsync(request));
        }

        // [CustomAuthorize("Admin")]
        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutUpdateAsync([FromRoute] Guid id, [FromBody] IncidentUpdateRequestDto request)
        {
            return !ModelState.IsValid ? CustomResponse(StatusCodes.Status400BadRequest, ModelState) : CustomResponse(StatusCodes.Status204NoContent, await _incidentAppService.UpdateAsync(id, request));
        }

        //[CustomAuthorize("Admin")]
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            return CustomResponse(StatusCodes.Status204NoContent, await _incidentAppService.DeleteAsync(id)) ;
        }
    }
}

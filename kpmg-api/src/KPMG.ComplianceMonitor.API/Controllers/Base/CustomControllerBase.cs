using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace KPMG.ComplianceMonitor.Api.Controllers.Base;
//[Authorize]
[Route("api/[controller]")]
[Produces("application/json")]
[ApiController]
public abstract class CustomControllerBase : ControllerBase
{
    private readonly ICollection<string> _errors = [];

    protected ActionResult CustomResponse(int statusCode, object? result = null)
    {
        if (IsOperationValid())
        {
            return statusCode switch
            {
                StatusCodes.Status201Created => Created(),
                StatusCodes.Status204NoContent => NoContent(),
                _ => Ok(result),
            };
        }

        var resultObj = new ValidationProblemDetails(new Dictionary<string, string[]>
        {
            { "Messages", _errors.ToArray() }
        });

        return statusCode switch
        {
            StatusCodes.Status400BadRequest => BadRequest(resultObj),
            StatusCodes.Status404NotFound => NotFound(resultObj),
            StatusCodes.Status409Conflict => Conflict(resultObj),
            _ => BadRequest(result)
        };
    }

    protected ActionResult CustomResponse(int statusCode, ModelStateDictionary modelState)
    {
        var errors = modelState.Values.SelectMany(e => e.Errors);
        foreach (var error in errors)
        {
            AddError(error.ErrorMessage);
        }

        return _errors.Count > 0 ? BadRequest(errors) : CustomResponse(statusCode);
    }

    protected ActionResult CustomResponse(int statusCode, ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            AddError(error.ErrorMessage);
        }

        if (_errors.Count > 0)
            statusCode = StatusCodes.Status400BadRequest;

        return CustomResponse(statusCode);
    }

    protected ActionResult CustomResponse()
    {
        return CustomResponse(StatusCodes.Status200OK);
    }

    protected bool IsOperationValid()
    {
        return _errors.Count == 0;
    }

    protected void AddError(string erro)
    {
        _errors.Add(erro);
    }

    protected void ClearErrors()
    {
        _errors.Clear();
    }
}

using AutoMapper;
using FluentValidation.Results;
using KPMG.ComplianceMonitor.Domain.Core.Interfaces;

namespace KPMG.ComplianceMonitor.Domain.Core.Messaging;

public abstract class CommandHandler
{
    protected ValidationResult ValidationResult;
    protected IMapper _mapper;

    protected CommandHandler(IMapper mapper)
    {
        ValidationResult = new ValidationResult();

        _mapper = mapper;
    }

    protected void AddError(string mensagem)
    {
        ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
    }

    protected async Task<ValidationResult> CommitAsync(IUnitOfWork uow, string message)
    {
        if (!await uow.CommitAsync()) AddError(message);

        return ValidationResult;
    }

    protected async Task<ValidationResult> CommitAsync(IUnitOfWork uow)
    {
        return await CommitAsync(uow, "Ocorreu um erro ao salvar os dados").ConfigureAwait(false);
    }
}
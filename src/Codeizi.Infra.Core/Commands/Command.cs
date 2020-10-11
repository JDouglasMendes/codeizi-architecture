using Codeizi.Infra.Core.Events;
using FluentValidation.Results;
using MediatR;

namespace Codeizi.Infra.Core.Commands
{
    public abstract class Command : Message,
        IRequest<ValidationResult>,
        IBaseRequest
    {
        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();
    }
}
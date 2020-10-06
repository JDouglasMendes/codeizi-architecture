using Codeizi.Infra.Core.Events;
using FluentValidation.Results;

namespace Codeizi.Infra.Core.Commands
{
    public abstract class Command : Message
    {
        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();
    }
}
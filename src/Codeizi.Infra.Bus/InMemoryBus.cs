using Codeizi.DI.Helper.Anotations;
using Codeizi.Infra.Core.Commands;
using Codeizi.Infra.Core.Events;
using Codeizi.Infra.Core.MediatorBus;
using FluentValidation.Results;
using MediatR;
using System.Threading.Tasks;

namespace Codeizi.Infra.Bus
{
    [Injectable(typeof(IMediatorHandler),
                typeof(InMemoryBus))]
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
            => _mediator = mediator;

        public Task RaiseEvent<T>(T @event)
            where T : Event
            => _mediator.Publish(@event);

        public async Task<ValidationResult> SendCommand<T>(T command)
            where T : Command
        {
            return await _mediator.Send<ValidationResult>(command);
        }

    }
}
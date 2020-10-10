using Codeizi.Infra.Core.Events;
using Codeizi.Infra.Core.MediatorBus;
using Codeizi.Infra.Core.Notifications;
using Codeizi.Infra.Core.UOW;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Codeizi.Infra.Core.Commands
{
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        protected IMediatorHandler Bus { get; }
        private readonly List<Event> events;
        private readonly List<DomainNotification> domainNotifications;

        protected CommandHandler(
            IUnitOfWork uow,
            IMediatorHandler bus)
            : this()
        {
            _uow = uow;
            Bus = bus;
        }

        private CommandHandler()
        {
            events = new List<Event>();
            domainNotifications = new List<DomainNotification>();
        }

        protected void AddEvent(Event @event)
            => events.Add(@event);

        protected void NotifyUser(
            string key,
            string message)
            =>
            domainNotifications.Add(new DomainNotification(key, message));

        public static ValidationResult Ok()
            => new ValidationResult();

        public static ValidationResult Error(
            string message,
            string property)
            => new ValidationResult(new List<ValidationFailure>
            {
                new ValidationFailure(property, message)
            });

        public async Task<ValidationResult> CommitAsync()
        {
            try
            {
                if (await _uow.Commit())
                {
                    events.ForEach(async @event =>
                    {
                        await Bus.RaiseEvent(@event);
                    });

                    domainNotifications.ForEach(async notification =>
                    {
                        await Bus.RaiseEvent(notification);
                    });

                    return Ok();
                }
                return Error("Failure in commit, please try again", "Commit");
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch
            {
                return Error("Error in commit Action, please try again", "Commit");
            }
#pragma warning restore CA1031 // Do not catch general exception types
        }
    }
}
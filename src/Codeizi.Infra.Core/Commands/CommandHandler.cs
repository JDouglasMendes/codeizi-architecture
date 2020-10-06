using Codeizi.Infra.Core.MediatorBus;
using Codeizi.Infra.Core.Notifications;
using Codeizi.Infra.Core.UOW;
using MediatR;
using System;

namespace Codeizi.Infra.Core.Commands
{
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        protected IMediatorHandler Bus { get; }
        private readonly DomainNotificationHandler _notifications;

        protected CommandHandler(
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _notifications = (DomainNotificationHandler)notifications;
            Bus = bus;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
                Bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
        }

        public async System.Threading.Tasks.Task<bool> CommitAsync()
        {
            if (_notifications.HasNotifications())
                return true;

            try
            {
                if (await _uow.Commit())
                    return true;

                await Bus.RaiseEvent(new DomainNotification("Commit", "Failure on commit"));
                return false;
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
            {
                await Bus.RaiseEvent(new DomainNotification("Commit", $"MESSAGE:{ex.Message}"));
                return false;
            }
#pragma warning restore CA1031 // Do not catch general exception types
        }
    }
}
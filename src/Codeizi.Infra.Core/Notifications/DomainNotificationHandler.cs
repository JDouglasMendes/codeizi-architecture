using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Codeizi.Infra.Core.Notifications
{
    public class DomainNotificationHandler :
        INotificationHandler<DomainNotification>,
        IDisposable
    {
        private List<DomainNotification> _notifications;
        private bool disposedValue;

        public DomainNotificationHandler()
            => _notifications = new List<DomainNotification>();

        public Task Handle(
            DomainNotification notification,
            CancellationToken cancellationToken)
        {
            _notifications.Add(notification);

            return Task.CompletedTask;
        }

        public virtual List<DomainNotification> GetNotifications()
            => _notifications;

        public virtual bool HasNotifications()
            => GetNotifications().Any();

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                    _notifications = new List<DomainNotification>();

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
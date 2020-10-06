using Codeizi.Infra.Core.Commands;
using Codeizi.Infra.Core.Events;
using System.Threading.Tasks;

namespace Codeizi.Infra.Core.MediatorBus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command)
        where T : Command;

        Task RaiseEvent<T>(T @event)
            where T : Event;
    }
}
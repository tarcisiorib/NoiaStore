using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Clients.API.Application.Events
{
    public class ClientEventHandler : INotificationHandler<ClientRegisteredEvent>
    {
        public Task Handle(ClientRegisteredEvent notification, CancellationToken cancellationToken)
        {
            // send event confirmation
            return Task.CompletedTask;
        }
    }
}

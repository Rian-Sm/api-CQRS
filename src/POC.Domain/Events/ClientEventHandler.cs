using MediatR;

namespace POC.Domain.Events
{
    public class ClientEventHandler : INotificationHandler<ClientRegisteredEvent>
    {
        public Task Handle(ClientRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

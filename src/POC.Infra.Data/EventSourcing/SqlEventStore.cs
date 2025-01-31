using NetDevPack.Messaging;
using POC.Domain.Events;

namespace POC.Infra.Data.EventSourcing
{
    public class SqlEventStore : IEventStore
    {

        public void Save<T>(T theEvent) where T : Event
        {
            throw new NotImplementedException();
        }
    }
}

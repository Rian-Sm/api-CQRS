using NetDevPack.Messaging;
using POC.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

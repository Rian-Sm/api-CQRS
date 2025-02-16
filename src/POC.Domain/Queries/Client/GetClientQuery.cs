using MediatR;
using NetDevPack.Messaging;
using POC.Domain.ViewModel;

namespace POC.Domain.Queries.Client
{
    public class GetClientQuery : Command, IRequest<IEnumerable<ClientListViewModel>>
    {
        
    }
}
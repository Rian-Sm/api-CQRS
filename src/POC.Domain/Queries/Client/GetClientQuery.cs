using MediatR;
using NetDevPack.Messaging;
using POC.Domain.ViewModel;
using POC.Infra.CrossCutting.Cache.Models;

namespace POC.Domain.Queries.Client
{
    public class GetClientQuery : Query, IRequest<IEnumerable<ClientListViewModel>>
    {
        
    }
}
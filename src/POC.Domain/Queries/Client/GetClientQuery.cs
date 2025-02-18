using MediatR;

using POC.Infra.CrossCutting.Cache.Models;

namespace POC.Domain.Queries.Client
{
    public class GetClientQuery : Query, IRequest<IEnumerable<Models.Client>>
    {
        
    }
}
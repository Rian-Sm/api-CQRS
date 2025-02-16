
using MediatR;
using POC.Domain.Interfaces;
using POC.Domain.ViewModel;

namespace POC.Domain.Queries.Client
{
    public class ClientQueryHandler : IRequestHandler<GetClientQuery, IEnumerable<ClientListViewModel>>
    {
        private readonly IClientRepository _clientRepository;

        public ClientQueryHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
         }


        public async Task<IEnumerable<ClientListViewModel>> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            return (IEnumerable<ClientListViewModel>)_clientRepository.GetAll();
        }
    }


}
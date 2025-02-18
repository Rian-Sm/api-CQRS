
using MediatR;
using POC.Domain.Interfaces;
using POC.Domain.Models;

namespace POC.Domain.Queries.Client
{
    public class ClientQueryHandler : IRequestHandler<GetClientQuery, IEnumerable<Models.Client>>
    {
        private readonly IClientRepository _clientRepository;

        public ClientQueryHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
         }


        public async Task<IEnumerable<Models.Client>> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Models.Client> clientList =  _clientRepository.Cache.GetCache<IEnumerable<Models.Client>>(typeof(GetClientQuery).ToString());

            if (clientList == null){
                var Items =  await _clientRepository.GetAll();

               return _clientRepository.Cache.SetCache(
                    typeof(GetClientQuery).ToString(),
                    Items
                    );
            }

            return clientList;
        }
    }


}
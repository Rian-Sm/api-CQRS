using AutoMapper;
using FluentValidation.Results;
using NetDevPack.Mediator;
using POC.Domain.Commands;
using POC.Domain.Interfaces;
using POC.Domain.Models;
using POC.Domain.ViewModel;
using POC.SERVICE.API.Interfaces;

namespace POC.SERVICE.API.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public ClientService(IClientRepository clientRepository, IMapper mapper, IMediatorHandler mediator){
            _clientRepository = clientRepository;
            _mapper = mapper;
            _mediator = mediator;
        }
        
        //private readonly IEventStoreRepository _eventStoreRepository;

        public async Task<IEnumerable<ClientViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ClientViewModel>>(await _clientRepository.GetAll());
        }

        public async Task<ClientViewModel> GetByEmail(string email)
        {
            return _mapper.Map<ClientViewModel>(await _clientRepository.GetByEmail(email));
        }

        public async Task<ClientViewModel> GetById(Guid id)
        {
            return _mapper.Map<ClientViewModel>(await _clientRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(ClientViewModel clientViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewClientCommand>(clientViewModel);
        
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Remove(Guid id)
        {
            var deleteCommand = new  DeleteClientCommand(id);
            return await _mediator.SendCommand(deleteCommand);
        }

        public async Task<ValidationResult> Update(ClientViewModel clientViewModel)
        {
            var  updateCommand = _mapper.Map<UpdateClientCommand>(clientViewModel);

            return await _mediator.SendCommand(updateCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;
using POC.Domain.Encrypt;
using POC.Domain.Interfaces;
using POC.Domain.Models;

namespace POC.Domain.Commands
{
    public class ClientCommandHandler : CommandHandler
    ,IRequestHandler<RegisterNewClientCommand, ValidationResult>
    ,IRequestHandler<UpdateClientCommand, ValidationResult>
    ,IRequestHandler<DeleteClientCommand, ValidationResult>
    {
        private readonly IClientRepository _clientRepository;

        public ClientCommandHandler(IClientRepository clientRepository
                               
         ) {
            _clientRepository = clientRepository;
         }

        public async Task<ValidationResult> Handle(RegisterNewClientCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var client = new Client(Guid.NewGuid(),  
                message.Email, 
                PasswordHasher.HashPassword(message.Password),
                string.Empty);

            if (await _clientRepository.GetByEmail(client.Email) != null)
            {
                AddError("The client e-mail has already been taken.");
                return ValidationResult;
            }

            _clientRepository.Add(client);

            return await Commit(_clientRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateClientCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            Client? client = await _clientRepository.GetById(message.Id);

            if (client == null)
            {
                AddError("The client ID not exist");
                return ValidationResult;
            }

            client.Email = message.Email;
            client.Password = PasswordHasher.HashPassword(message.Password);

            _clientRepository.Update(client);


            return await Commit(_clientRepository.UnitOfWork);

        }

        public async Task<ValidationResult> Handle(DeleteClientCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            Client? client = await _clientRepository.GetById(message.Id);

            if (client == null)
            {
                AddError("The client ID not exist");
                return ValidationResult;
            }

            _clientRepository.Remove(client);

            return await Commit(_clientRepository.UnitOfWork);   
        }
    }
}
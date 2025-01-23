using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;
using POC.Domain.Encrypt;
using POC.Domain.Interfaces;
using POC.Domain.Models;

namespace POC.SERVICE.API.Commands
{
    public class ClientCommandHandler : CommandHandler
    ,IRequestHandler<RegisterNewClientCommand, ValidationResult>
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
                AddError("The customer e-mail has already been taken.");
                return ValidationResult;
            }

            _clientRepository.Add(client);

            return await Commit(_clientRepository.UnitOfWork);
        }
    }
}
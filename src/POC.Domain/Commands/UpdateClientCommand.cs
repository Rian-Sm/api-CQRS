using POC.Domain.Commands.Validations;

namespace POC.Domain.Commands
{
    public class UpdateClientCommand : ClientCommand
    {
        public UpdateClientCommand(Guid id, string email, string password ){
            Id = id;
            Email = email;
            Password = password;
        }

        public override bool IsValid(){
            ValidationResult = new UpdateClientValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        
    }
}
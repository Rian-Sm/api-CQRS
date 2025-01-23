using POC.Domain.Commands.Validations;

namespace POC.Domain.Commands
{
    public class RegisterNewClientCommand : ClientCommand
    {
        public RegisterNewClientCommand(string email, string password){
            Email = email;
            Password = password;
        }

        public override bool IsValid(){
            ValidationResult = new RegisterNewClientValidation().Validate(this);
            return ValidationResult.IsValid;
        }

       
    }
}
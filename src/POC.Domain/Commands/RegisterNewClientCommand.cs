using POC.SERVICE.API.Commands.Validations;

namespace POC.SERVICE.API.Commands
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
namespace POC.Domain.Commands.Validations
{
    public class RegisterNewClientValidation : ClientValidation
    {
        public RegisterNewClientValidation(){
            ValidateEmail();
            ValidatePassword();
        }
    }
}
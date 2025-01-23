namespace POC.SERVICE.API.Commands.Validations
{
    public class RegisterNewClientValidation : ClientValidation
    {
        public RegisterNewClientValidation(){
            ValidateEmail();
            ValidatePassword();
        }
    }
}
namespace POC.Domain.Commands.Validations
{
    public class UpdateClientValidation : ClientValidation
    {
        public UpdateClientValidation(){
            ValidateId();
            ValidateEmail();
            ValidatePassword();
        }
    }
}
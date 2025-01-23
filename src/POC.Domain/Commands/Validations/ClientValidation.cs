using FluentValidation;

namespace POC.SERVICE.API.Commands.Validations
{
    public abstract class ClientValidation : AbstractValidator<ClientCommand>  
    {
        protected void ValidateEmail(){
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();
        }

        protected void ValidatePassword()
        {
            RuleFor(c => c.Password)
                .NotEmpty()
                .Length(8, 150).WithMessage("The Password must have between 8 and 150 characters");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateAccessToken()
        {
            RuleFor(c => c.AccessToken)
                .NotEqual(String.Empty);
        }
    }
}
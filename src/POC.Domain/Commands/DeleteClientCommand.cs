using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POC.Domain.Commands.Validations;

namespace POC.Domain.Commands
{
    public class DeleteClientCommand : ClientCommand
    {
        public DeleteClientCommand(Guid id){
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeleteClientValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
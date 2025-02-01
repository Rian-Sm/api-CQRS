using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC.Domain.Commands.Validations
{
    public class DeleteClientValidation : ClientValidation
    {
        public DeleteClientValidation(){
            ValidateId();
        }
    }
}
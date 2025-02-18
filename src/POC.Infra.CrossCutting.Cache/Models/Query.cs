using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace POC.Infra.CrossCutting.Cache.Models
{
    public abstract class Query : IBaseRequest, IRequest
    {
        public DateTime Timestamp { get; private set; }

        public Query(){
            Timestamp = DateTime.Now;
        }    
        
        public virtual bool Isvalid(){
            return true;
        }
    }
}
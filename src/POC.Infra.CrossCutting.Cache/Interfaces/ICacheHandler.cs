using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC.Infra.CrossCutting.Cache.Interfaces
{
    public interface ICacheHandler
    {
         public Task<Object> SendQuery<T>(T Query);
    }
}
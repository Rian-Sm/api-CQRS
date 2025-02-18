using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POC.Infra.CrossCutting.Cache.Models;

namespace POC.Infra.CrossCutting.Cache.Interfaces
{
    public interface ICacheHandler
    {
         public Task<Object> SendQuery<T>(T Query);
         public bool GetValue<T>(string key, out T value);
         public T SetValue<T>(string key, T Value);
    }
}
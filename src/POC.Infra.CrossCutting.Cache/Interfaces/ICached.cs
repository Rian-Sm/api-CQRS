using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POC.Infra.CrossCutting.Cache.Models;

namespace POC.Infra.CrossCutting.Cache.Interfaces
{
    public interface ICached
    {
        public T GetCache<T>(string key);
        public T SetCache<T>(string key, T cacheItem);
    }
}
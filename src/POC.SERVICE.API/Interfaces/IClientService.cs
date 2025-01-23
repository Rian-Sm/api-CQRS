using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POC.SERVICE.API.ViewModel;

namespace POC.SERVICE.API.Interfaces
{
    public interface IClientService : IDisposable
    {
        Task<ClientViewModel> GetById(Guid id);
    }
}
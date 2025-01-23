
using FluentValidation.Results;
using POC.Domain.ViewModel;

namespace POC.SERVICE.API.Interfaces
{
    public interface IClientService : IDisposable
    {
        Task<ClientViewModel> GetById(Guid id);
        Task<ClientViewModel> GetByEmail(string email);

        Task<IEnumerable<ClientViewModel>> GetAll();
        
        Task<ValidationResult> Register(ClientViewModel clientViewModel);
        Task<ValidationResult> Update(ClientViewModel clientViewModel);

        Task<ValidationResult> Remove (Guid id);

    }
}
using NetDevPack.Data;
using POC.Domain.Models;

namespace POC.Domain.Interfaces
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<Client?> GetById(Guid id);
        Task<Client?> GetByEmail(string email);
        Task<IEnumerable<Client>> GetAll();

        void Add(Client customer);
        void Update(Client customer);
        void Remove(Client customer);
    }
}
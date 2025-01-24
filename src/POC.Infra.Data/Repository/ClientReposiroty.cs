using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using POC.Domain.Interfaces;
using POC.Domain.Models;
using POC.Infra.Data.Context;

namespace POC.Infra.Data.Repository
{
    public class ClientReposiroty : IClientRepository
    {
        protected readonly POCContext Db;
        protected readonly DbSet<Client> DbSet;

        public ClientReposiroty(POCContext context){
            Db = context;
            DbSet = Db.Set<Client>();
        }
        public IUnitOfWork UnitOfWork => Db;

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Client> GetByEmail(string email)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Email == email);

        }

        public async Task<Client> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Add(Client client)
        {
            DbSet.Add(client);
        }

        public void Remove(Client client)
        {
            DbSet.Remove(client);
        }

        public void Update(Client client)
        {
            DbSet.Update(client);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
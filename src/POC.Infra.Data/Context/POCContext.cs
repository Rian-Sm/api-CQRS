using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using NetDevPack.Mediator;

namespace POC.Infra.Data.Context
{
    public class POCContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public Task<bool> Commit()
        {
            throw new NotImplementedException();
        }
    }
}
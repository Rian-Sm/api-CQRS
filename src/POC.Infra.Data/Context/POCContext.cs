using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using NetDevPack.Domain;
using NetDevPack.Mediator;
using NetDevPack.Messaging;
using POC.Domain.Models;

namespace POC.Infra.Data.Context
{
    public class POCContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public POCContext(DbContextOptions<POCContext> options, IMediatorHandler madiatorHandler): base (options){
            _mediatorHandler = madiatorHandler;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }   

        public DbSet<Client> Clients{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            await _mediatorHandler.PublishDomainEvents(this).ConfigureAwait(false);

            var sucess = await SaveChangesAsync() > 0;

            return sucess;
        }
    }

    public static class MediatorExtension {
        public static async Task PublishDomainEvents<T>(
            this IMediatorHandler mediator,
            T ctx) where T : DbContext 
            {
                var domainEntities = ctx.ChangeTracker
                    .Entries<Entity>()
                    .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

                var domainEvents = domainEntities
                    .SelectMany(x => x.Entity.DomainEvents)
                    .ToList();

                domainEntities.ToList()
                    .ForEach(entity => entity.Entity.ClearDomainEvents());

                var tasks = domainEvents
                    .Select(async (domainEvents) => {
                        await mediator.PublishEvent(domainEvents);
                });

                await Task.WhenAll(tasks);

            }
    }
}
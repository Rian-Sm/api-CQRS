using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using NetDevPack.Domain;
using NetDevPack.Mediator;
using NetDevPack.Messaging;
using POC.Domain.Models;
using POC.Infra.CrossCutting.Cache.Interfaces;
using POC.Infra.CrossCutting.Cache.Models;

namespace POC.Infra.Data.Context
{
    public class POCContext : DbContext, IUnitOfWork, ICached
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly ICacheHandler _cache;

        public POCContext(DbContextOptions<POCContext> options, IMediatorHandler madiatorHandler, ICacheHandler cache): base (options){
            _mediatorHandler = madiatorHandler;
            _cache = cache;
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

        public T GetCache<T>(string key)
        {
            Object item;

            _cache.GetValue(key, out item);

            return (T) item;
        }

        public T SetCache<T>(string key, T cacheItem)
        {
            return _cache.SetValue(key, cacheItem);
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
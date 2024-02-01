using BuberDinner.Domain.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BuberDinner.Infrastructure.Persistence.Interceptors
{
    public class PublishDomainEventsInterceptor : SaveChangesInterceptor
    {
        private readonly IPublisher _mediator;
        public PublishDomainEventsInterceptor(IPublisher mediator)
        {
            _mediator = mediator;
        }
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            PublishDomainEvents(eventData.Context).GetAwaiter().GetResult();
            return base.SavingChanges(eventData, result);
        }

        public async override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            await PublishDomainEvents(eventData.Context);
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private async Task PublishDomainEvents(DbContext? dbContext)
        {
            if(dbContext is null)
            {
                return;
            }
            // Get hold of all the various entities
            var entititesWithDomainEvents = dbContext.ChangeTracker.Entries<IHasDomainEvents>()
                .Where(entry => entry.Entity.DomainEvents.Any())
                .Select(entry => entry.Entity)
                .ToList();

            var domainEvents = entititesWithDomainEvents.SelectMany(entry => entry.DomainEvents).ToList();

            entititesWithDomainEvents.ForEach(entity => entity.ClearDomainEvent());
            
            foreach(var domainEvent in domainEvents)
            {
                await _mediator.Publish(domainEvent);
            }
            // Get hold of all the various domain events
            // Publish domain events
            // Clear domain events
        }
    }
}
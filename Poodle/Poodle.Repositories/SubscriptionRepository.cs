using Poodle.Data;
using Poodle.Data.EntityModels;
using Poodle.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poodle.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly ApplicationContext context;

        public SubscriptionRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IQueryable<Subscription> GetAll()
         => context.Subscriptions;

        public async Task<int> Delete(Subscription subscriptionToDelete)
        {
            this.context.Subscriptions.Remove(subscriptionToDelete);
            await this.context.SaveChangesAsync();
            return subscriptionToDelete.Id;
        }

        public async Task<int> Add(Subscription subscriptionToAdd)
        {
            var newSubscription = await this.context.Subscriptions.AddAsync(subscriptionToAdd);
            await this.context.SaveChangesAsync();
            return newSubscription.Entity.Id;
        }
    }
}

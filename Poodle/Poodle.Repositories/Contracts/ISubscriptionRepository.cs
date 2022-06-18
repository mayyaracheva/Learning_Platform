using Poodle.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poodle.Repositories.Contracts
{
    public interface ISubscriptionRepository
    {
        IQueryable<Subscription> GetAll();
        Task<int> Add(Subscription subscriptionToAdd);
        Task<int> Delete(Subscription subscriptionToDelete);
    }
}

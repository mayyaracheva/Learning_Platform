using Microsoft.EntityFrameworkCore;
using Poodle.Data.EntityModels;
using Poodle.Repositories.Contracts;
using Poodle.Services.Constants;
using Poodle.Services.Contracts;
using Poodle.Services.Exceptions;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace Poodle.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository subsriptionRepository;
        public SubscriptionService(ISubscriptionRepository subsriptionRepository)
        {
            this.subsriptionRepository = subsriptionRepository;
        }

        public async Task<List<Subscription>> GetAll()
           => await this.subsriptionRepository.GetAll().ToListAsync();
        

        public async Task<Subscription> GetByEmail(string email)
           => (await this.GetAll()).Where(Subscription => Subscription.EmailAddress == email).FirstOrDefault();

        public async Task<int> Add(string email)
        {
            var currentSubscriptions = await this.GetAll();

            if (currentSubscriptions.Any(s => s.EmailAddress == email.Trim()))
            {
                throw new DuplicateEntityException(ConstantsContainer.SUBSCRIPTION_EXISTS);
            }
            var subscription = new Subscription();
            subscription.EmailAddress = email;
            return await this.subsriptionRepository.Add(subscription);
        }
        public async Task<int> Delete(string email)
        {
            var subscription = await this.GetByEmail(email.Trim());

            if (subscription == null)
            {
                throw new EntityNotFoundException(ConstantsContainer.SUBSCRIPTION_NOT_FOUND);
            }
           return await this.subsriptionRepository.Delete(subscription);
        }
    }
}

using Poodle.Data.EntityModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poodle.Services.Contracts
{
    public interface ISubscriptionService
    {
        Task<List<Subscription>> GetAll();        
        Task<Subscription> GetByEmail(string email);
        Task<int> Delete(string email);
        Task<int> Add(string email);

    }
}

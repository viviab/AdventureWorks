using AdventureWorks.Core.Entities.EF;
using AdventureWorks.Core.Interfaces.Persistance.Repositories;
using AdventureWorks.Core.Persistance.Context;

namespace AdventureWorks.Core.Persistance.Repositories.Stores
{
    public class StoreRepository : GenericRepository<Store>, IStoreRepository
    {
        public StoreRepository(AdventureWorksContext dbContext) : base(dbContext)
        {

        }
    }
}

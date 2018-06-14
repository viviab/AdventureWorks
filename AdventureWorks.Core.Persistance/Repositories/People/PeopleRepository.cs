using AdventureWorks.Core.Entities.EF;
using AdventureWorks.Core.Interfaces.Persistance.Repositories;
using AdventureWorks.Core.Persistance.Context;

namespace AdventureWorks.Core.Persistance.Repositories.People
{
    public class PeopleRepository : GenericRepository<Person>, IPeopleRepository
    {
        public PeopleRepository(AdventureWorksContext dbContext) : base(dbContext)
        {
        }
           
    }
}

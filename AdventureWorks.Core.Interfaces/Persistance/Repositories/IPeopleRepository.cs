using AdventureWorks.Core.Entities.EF;

namespace AdventureWorks.Core.Interfaces.Persistance.Repositories
{
    public interface IPeopleRepository
    {
        void Add(Person entity);
    }
}

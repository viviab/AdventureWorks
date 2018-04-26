using AdventureWorks.UI.ViewEntities.People;

namespace AdventureWorks.Core.Interfaces.BussinesLogic.Services.People
{
    public interface IPeopleAdderService
    {
        int Add(PersonRequest personRequest);
    }
}

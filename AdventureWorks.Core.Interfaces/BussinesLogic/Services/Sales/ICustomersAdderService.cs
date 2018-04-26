using AdventureWorks.UI.ViewEntities.Sales;

namespace AdventureWorks.Core.Interfaces.BussinesLogic.Services.Sales
{
    public interface ICustomersAdderService
    {
        int Add(CustomerRequest customer);
    }
}

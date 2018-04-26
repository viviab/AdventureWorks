using System.Collections.Generic;
using AdventureWorks.UI.ViewEntities.Sales;

namespace AdventureWorks.Core.Interfaces.BussinesLogic.Services.Sales
{
    public interface ICustomersGetterService
    {
        CustomerViewEntity GetById(int customerId);
        IEnumerable<CustomerViewEntity> GetAll();
    }
}

using AdventureWorks.UI.ViewEntities.Sales;
using System.Collections.Generic;

namespace AdventureWorks.Core.Interfaces.BussinesLogic.Services.Sales
{
    public interface ICustomersGetterService
    {
        CustomerViewEntity GetById(int customerId);

        IEnumerable<CustomerViewEntity> GetAll(int? numberOfResult = null);
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorks.Core.Entities.EF
{
    [Table("Store", Schema = "Sales")]
    public class Store
    {
        [Key]
        public virtual int BusinessEntityId { get; set; }
        public virtual string Name { get; set; }
        public virtual int SalesPersonId { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorks.Core.Entities.EF
{
    [Table("Customer", Schema = "Sales")]
    public class Customer
    {
        [Key]
        public virtual int CustomerId { get; set; }
        public virtual int? PersonId { get; set; }
        public virtual int? StoreId { get; set; }
        public virtual int? TerritoryId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public virtual string AccountNumber { get; private set; }
        public virtual DateTime ModifiedDate { get; set; }
    }
}

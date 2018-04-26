using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorks.Core.Entities.EF
{
    [Table("Person", Schema = "Person")]
    public class Person
    {
        [Key]
        public virtual int BusinessEntityId { get; set; }
        public virtual string PersonType { get; set; }
        public virtual string Title { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual int EmailPromotion { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
    }
}

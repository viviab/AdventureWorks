using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.UI.ViewEntities.People
{
    public class PersonRequest
    {
        public string PersonType { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int EmailPromotion { get; set; }
        public DateTime DateOfBirth { get; set; }


        public bool HasCompleteName()
        {
            return !string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(MiddleName) && !string.IsNullOrWhiteSpace(LastName); 
        }

        public bool IsAdult()
        {
            return (new DateTime(1, 1, 1) + (DateTime.Now - DateOfBirth)).Year - 1 >= 18; 
        }
    }
}

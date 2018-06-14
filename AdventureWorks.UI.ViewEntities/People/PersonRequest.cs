using System;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorks.UI.ViewEntities.People
{
    public class PersonRequest
    {
        [Required]
        public string PersonType { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int EmailPromotion { get; set; }

        [Required]
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

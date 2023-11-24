using System;
using System.ComponentModel.DataAnnotations;

namespace Life_Liberator.Models
{

    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public ProgrammingLanguage ProgrammingLanguage { get; set; }

        public ProficiencyLevel ProficiencyLevel { get; set; }

        public required string WorkTimeSlots { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

using System;
namespace Life_Liberator.Models
{

    public class User
    {
        

        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }

        public ProgrammingLanguage ProgrammingLanguage { get; set; }

        public ProficiencyLevel ProficiencyLevel { get; set; }

        public required string WorkTimeSlots { get; set; }

        public required string Password { get; set; }
    }
}


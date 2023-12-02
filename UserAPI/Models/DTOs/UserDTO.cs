using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models.DTO;


    public class UserDTO
{
    public int Id { get; set; } //primary key

    [Required(ErrorMessage = "First Name is required")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is required")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; }

    public ProficiencyLevel ProficiencyLevel { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    // Navigation property for associated schedules
    public List<Schedule> CustomSchedules { get; set; }


}


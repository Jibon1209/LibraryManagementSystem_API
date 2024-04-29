using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class Member
    {
        [Key]
        public int MemberID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime? RegistrationDate { get; set; }

    }
}

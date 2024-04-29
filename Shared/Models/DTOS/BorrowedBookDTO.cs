using System.ComponentModel.DataAnnotations;

namespace Shared.Models.DTOS
{

    public class BorrowedBookDTO
    {
        [Key]
        public int BorrowID { get; set; }
        [Required]
        public DateTime BorrowDate { get; set; }
        [Required]
        public int MemberId { get; set; }
        public string? MemberFullName { get; set; }
        public DateTime? ReturnDate { get; set; }
        [Required]
        public int BookId { get; set; }
        public string? Title { get; set; }
        [Required]
        public string Status { get; set; }
    }
}

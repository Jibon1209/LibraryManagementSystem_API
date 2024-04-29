using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class BorrowedBook
    {
        [Key]
        public int BorrowID { get; set; }
        [Required]
        public DateTime BorrowDate { get; set; }
        [Required]
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public DateTime? ReturnDate { get; set; }
        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }
        [Required]
        public string Status { get; set; }
    }
}

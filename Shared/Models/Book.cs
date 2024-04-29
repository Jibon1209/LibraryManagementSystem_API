using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        [Required]
        public DateTime PublishedDate { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int AvailableCopies { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public int TotalCopies { get; set; }
        [Required]
        public int AuthorID { get; set; }
        public Author Author { get; set; }
    }
}

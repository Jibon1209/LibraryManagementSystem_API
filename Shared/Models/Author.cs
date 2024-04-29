using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }
        [Required]
        public string AuthorName { get; set; }
        public string? AuthorBio {  get; set; }
    }
}

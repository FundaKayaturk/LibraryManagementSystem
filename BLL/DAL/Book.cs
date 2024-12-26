using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        
        [Range(0, int.MaxValue, ErrorMessage = "Available copies cannot be greater than total copies.")]
        public int AvailableCopies { get; set; }

        public int TotalCopies { get; set; }
        
        
        [Required(ErrorMessage = "Authors is required!")]
        public int? AuthorId { get; set; }
        public Author Author { get; set; } 
        
        public List<BookCategory> BookCategories { get; set; } = new List<BookCategory>();
    }
}
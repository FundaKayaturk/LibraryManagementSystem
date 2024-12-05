using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(75)]
        public string Genre { get; set; }
        public int PublicationYear { get; set; }
        
        [Range(0, int.MaxValue, ErrorMessage = "Available copies cannot be greater than total copies.")]
        public int AvailableCopies { get; set; }

        public int TotalCopies { get; set; }

        public void UpdateAvailableCopies() 
        { 
            if (AvailableCopies > TotalCopies) 
            { 
                AvailableCopies = TotalCopies; 
            } 
        }

        public int? AuthorId { get; set; }
        public Author Author { get; set; } 
        public List<Category> CategoriesList { get; set; } = new List<Category>(); 
        public List<Reservation> Reservations { get; set; } = new List<Reservation>(); 
    }
}
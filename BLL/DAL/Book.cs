
namespace BLL.DAL
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PublicationYear { get; set; }
        public int AvailableCopies { get; set; }
        public int TotalCopies { get; set; }
        public int? AuthorId { get; set; }
        public Author Author { get; set; } // Bir kitap bir yazara aittir
        public List<Category> CategoriesList { get; set; } = new List<Category>(); // Bir kitap birden fazla kategoriye sahip olabilir
        public List<Reservation> Reservations { get; set; } = new List<Reservation>(); // Rezervasyonlar


    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.DAL
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
        public List<Book> Books { get; set; } = new List<Book>(); // Bir yazar birden fazla kitap yazabilir
    }
}
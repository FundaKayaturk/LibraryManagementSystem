using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        [StringLength(200)]
        public string Biography { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
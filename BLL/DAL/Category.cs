using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        
        public List<Book> Books { get; set; } = new List<Book>(); // Bir kategori birden fazla kitaba sahip olabilir
    }
}
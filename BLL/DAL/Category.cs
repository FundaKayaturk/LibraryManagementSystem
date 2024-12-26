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
        
        public List<BookCategory> BookCategories { get; set; } = new List<BookCategory>(); // Bir kategori birden fazla kitaba sahip olabilir
    }
}
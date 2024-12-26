using System.ComponentModel;
using BLL.DAL;

namespace BLL.Models
{
    public class BookModel
    {
        public Book Record { get; set; }

        public string Title => Record.Title;

        [DisplayName("Publication Year")]
        public string PublicationYear => Record.PublicationYear.ToString();

        public string AvailableCopies => Record.AvailableCopies.ToString();
        public string TotalCopies => Record.TotalCopies.ToString();

        public string Author => $"{Record.Author?.FirstName} {Record.Author?.LastName}";

        // way 1:
        //[DisplayName("Categories")]
        //public List<Category> CategoryList => Record.BookCategories?.Select(bc => bc.Category).ToList;
        
        // way 2:
        public string Categories => string.Join("<br>", Record.BookCategories?.Select(bc => bc.Category?.Name));

        [DisplayName("Categories")]
        public List<int> CategoryIds
        {
            get => Record.BookCategories?.Select(bc => bc.CategoryId).ToList();
            set => Record.BookCategories = value.Select(v => new BookCategory { CategoryId = v }).ToList();
        }
    }
}
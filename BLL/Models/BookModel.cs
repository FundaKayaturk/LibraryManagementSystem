using System.ComponentModel;
using BLL.DAL;

namespace BLL.Models
{
    public class BookModel
    {
        public Book Record { get; set; }

        public string Title => Record.Title;
        

        public string Genre => Record.Genre;

        [DisplayName("Publication Year")]
        public string PublicationYear => Record.PublicationYear.ToString();

        public string AvailableCopies => Record.AvailableCopies.ToString();

        public string TotalCopies => Record.TotalCopies.ToString();

        public string Author => $"{Record.Author?.FirstName} {Record.Author?.LastName}";

    }
}
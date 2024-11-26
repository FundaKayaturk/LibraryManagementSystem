using System.ComponentModel;
using BLL.DAL;

namespace BLL.Models
{
    public class BookModel
    {
        public Book Record { get; set; }

        public string Title => Record.Title; // Varsayılan ad kullanıcı dostu
        

        public string Genre => Record.Genre; // Varsayılan ad kullanıcı dostu

        [DisplayName("Publication Year")]
        public string PublicationYear => Record.PublicationYear.ToString();

        public string AvailableCopies => Record.AvailableCopies.ToString();

        public string TotalCopies => Record.TotalCopies.ToString();
        public List<int> AuthorId {get; set;}

        public string Author => $"{Record.Author?.FirstName} {Record.Author?.LastName}";

    }
}
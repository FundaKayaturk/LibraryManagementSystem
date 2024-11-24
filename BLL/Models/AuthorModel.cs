using BLL.DAL;

namespace BLL.Models
{
    public class AuthorModel
    {
        public Author Record { get; set; }
        public string FirstName => Record.FirstName;
        public string LastName => Record.LastName;
        public string FullName => $"{FirstName} {LastName}";
        public string Biography => Record.Biography;
        

    }
}
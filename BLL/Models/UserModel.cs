using System.ComponentModel;
using BLL.DAL;

namespace BLL.Models
{
    public class UserModel
    {
        public User Record { get; set; }
        
        [DisplayName("User Name")]
        public string Username => Record.Username;
        
        public string Password => Record.Password;
        
        public string IsActive => Record.IsActive ? "Active" : "Inactive";

        public string Role => Record.Role?.Name;

    }
}
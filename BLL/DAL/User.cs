using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(300)]
        public string Address { get; set; }
        public DateTime MembershipDate { get; set; }
        
        public int RoleId { get; set; }
        public Role Role { get; set; } // Her kullanıcı bir role sahiptir.
    }
}
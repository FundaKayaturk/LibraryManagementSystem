namespace BLL.DAL
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public List<User> Users { get; set; } = new List<User>(); // Bir role birden fazla kullanıcı atanabilir

    }
}
using Microsoft.EntityFrameworkCore;

namespace BLL.DAL
{
    public class Db : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Category> Categories { get; set; }
        
        public Db(DbContextOptions<Db> options) : base(options)
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BLL.DAL;

    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<BLL.DAL.User> User { get; set; } = default!;

public DbSet<BLL.DAL.Role> Role { get; set; } = default!;

public DbSet<BLL.DAL.Book> Book { get; set; } = default!;

public DbSet<BLL.DAL.Author> Author { get; set; } = default!;
    }

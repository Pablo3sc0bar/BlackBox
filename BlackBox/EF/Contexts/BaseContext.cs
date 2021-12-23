using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlackBox.Entities.Accounting;
using BlackBox.Entities.ProductAdditionals;
using BlackBox.Entities.Ordering;

namespace BlackBox.EF.Contexts
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options)
               : base(options)
        { }
        #region DbSets
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Jenre> Jenres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<UsersAndBooks> UsersAndBooks { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().ToTable("Roles").HasData(
                new Role() { ID = 1, Name = "Admin" },
                new Role() { ID = 2, Name = "User" }
                );
            modelBuilder.Entity<User>().ToTable("Users").HasAlternateKey(u => u.Email);
            modelBuilder.Entity<User>().HasData(
                new User() { ID = 1, Name = "Admin", RoleId = 1, Email = "admin@ya.ru", Password = "admin" }
                );
            modelBuilder.Entity<Jenre>().ToTable("Jenres");
            modelBuilder.Entity<Author>().ToTable("Authors");
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Cart>().ToTable("Carts");
            modelBuilder.Entity<UsersAndBooks>().ToTable("UsersAndBooks").HasAlternateKey(u => new { u.BookID, u.UserID });

        }
    }
}
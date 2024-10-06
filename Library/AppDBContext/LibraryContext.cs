using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.AppDBContext
{
    public class LibraryContext : DbContext
    {
        public LibraryContext()
        {

        }

        public LibraryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<admin> admins { get; set; }
        public DbSet<authors> authorss { get; set; }
        public DbSet<books> bookss { get; set; }
        public DbSet<borrowingItem> borrowingItems { get; set; }
        public DbSet<borrowings> borrowingss { get; set; }
        public DbSet<genres> genress { get; set; }
        public DbSet<ratings> ratingss { get; set; }
        public DbSet<users> userss { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<admin>().HasKey(s => s.admin_ID);
            modelBuilder.Entity<authors>().HasKey(s => s.authors_ID);
            modelBuilder.Entity<books>().HasKey(s => s.books_ID);
            modelBuilder.Entity<borrowingItem>().HasKey(s => s.borrowingItem_ID);
            modelBuilder.Entity<borrowings>().HasKey(s => s.borrowings_ID);
            modelBuilder.Entity<genres>().HasKey(s => s.genres_ID);
            modelBuilder.Entity<ratings>().HasKey(s => s.ratings_ID);
            modelBuilder.Entity<users>().HasKey(s => s.users_ID);
        }
    }
}

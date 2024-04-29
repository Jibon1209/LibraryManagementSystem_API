using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace LibraryManagementSystem_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<BorrowedBook> BorrowedBooks { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           

            modelBuilder.Entity<BorrowedBook>()
                .Property(u => u.Status)
                .HasDefaultValue("Borrowed");

            modelBuilder.Entity<BorrowedBook>()
                .HasCheckConstraint("CK_BorrowedBook_Status", "[Status] IN ('Borrowed', 'Returned', 'Overdue')");

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    UserName = "Admin",
                    Password = "Admin"
                }
            );
        }
    }
}

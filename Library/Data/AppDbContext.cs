using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Library.Data
{
    public class AppDbContext : DbContext
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(connectionString);
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fixing Keys
            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new { ba.BookId, ba.AuthorId });
            modelBuilder.Entity<BookGenre>().HasKey(bg => new { bg.BookId, bg.GenreId });
            modelBuilder.Entity<BookCopy>()
                .HasKey(bc => new { bc.BookId, bc.CopyId });

            modelBuilder.Entity<LibraryBranch>()
                .HasKey(lb => lb.BranchId);

            // Relationships
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId);

            modelBuilder.Entity<BookCopy>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookCopies)
                .HasForeignKey(bc => bc.BookId);

            modelBuilder.Entity<BookCopy>()
                .HasOne(bc => bc.LibraryBranch)
                .WithMany(lb => lb.BookCopies)
                .HasForeignKey(bc => bc.BranchId);

            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Book)
                .WithMany(b => b.BookGenres)
                .HasForeignKey(bg => bg.BookId);

            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Genre)
                .WithMany(g => g.BookGenres)
                .HasForeignKey(bg => bg.GenreId);

            modelBuilder.Entity<Fine>()
                .HasOne(f => f.Loan)
                .WithMany(l => l.Fines)
                .HasForeignKey(f => f.LoanId);

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.BookCopy)
                .WithMany(bc => bc.Loans)
                .HasForeignKey(l => l.CopyId);

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.BookCopy)
                .WithMany(bc => bc.Loans)
                .HasForeignKey(l => new { l.BookId, l.CopyId });


            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Patron)
                .WithMany(p => p.Loans)
                .HasForeignKey(l => l.PatronId);

            modelBuilder.Entity<Staff>()
                .HasOne(s => s.LibraryBranch)
                .WithMany(lb => lb.Staffs)
                .HasForeignKey(s => s.BranchId);


            /*
             *------------------------------------------------------------------------------------
             *                               Correcting Names
             *------------------------------------------------------------------------------------
             */
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("author");
                entity.Property(a => a.AuthorId)
                    .HasColumnName("author_id");
                entity.Property(a => a.AuthorFirstName)
                    .HasColumnName("author_firstname");
                entity.Property(a => a.AuthorLastName)
                    .HasColumnName("author_lastname");
                entity.Property(a => a.AuthorBiography)
                    .HasColumnName("author_biography");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("book");
                entity.Property(b => b.BookId)
                    .HasColumnName("book_id");
            });

        }
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookCopy> BookCopies { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<Fine> Fines { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<LibraryBranch> LibraryBranches { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Patron> Patrons { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
    }
}
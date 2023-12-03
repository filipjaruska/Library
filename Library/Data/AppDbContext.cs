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

            /*
            // *------------------------------------------------------------------------------------
            // *                               Relationships
            // *------------------------------------------------------------------------------------
            */
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
                entity.Property(b => b.PublisherId)
                    .HasColumnName("publisher_id");
                entity.Property(b => b.BookIsbn)
                    .HasColumnName("book_isbn");
                entity.Property(b => b.BookTitle)
                    .HasColumnName("book_title");
                entity.Property(b => b.BookPublicationYear)
                    .HasColumnName("book_publicationyear");
            });

            modelBuilder.Entity<BookAuthor>(entity =>
            {
                entity.ToTable("book_author");
                entity.Property(ba => ba.AuthorId)
                    .HasColumnName("author_id");
                entity.Property(ba => ba.BookId)
                    .HasColumnName("book_id");
            });

            modelBuilder.Entity<BookCopy>(entity =>
            {
                entity.ToTable("book_copy");
                entity.Property(bc => bc.CopyId)
                    .HasColumnName("copy_id");
                entity.Property(bc => bc.BookId)
                    .HasColumnName("book_id");
                entity.Property(bc => bc.BranchId)
                    .HasColumnName("branch_id");
                entity.Property(bc => bc.CopyCondition)
                    .HasColumnName("copy_condition");
                entity.Property(bc => bc.CopyAcquisitionYear)
                    .HasColumnName("copy_acquisitionyear");
                entity.Property(bc => bc.CopyAvailable)
                    .HasColumnName("copy_available");
            });

            modelBuilder.Entity<BookGenre>(entity =>
            {
                entity.ToTable("book_genre");
                entity.Property(bg => bg.GenreId)
                    .HasColumnName("genre_id");
                entity.Property(bg => bg.BookId)
                    .HasColumnName("book_id");
            });

            modelBuilder.Entity<Fine>(entity =>
            {
                entity.ToTable("fine");
                entity.Property(f => f.FineId)
                    .HasColumnName("fine_id");
                entity.Property(f => f.LoanId)
                    .HasColumnName("loan_id");
                entity.Property(f => f.FineAmount)
                    .HasColumnName("fine_amount");
                entity.Property(f => f.FinePaid)
                    .HasColumnName("fine_paid");
                entity.Property(f => f.FineReason)
                    .HasColumnName("fine_reason");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genre");
                entity.Property(g => g.GenreId)
                    .HasColumnName("genre_id");
                entity.Property(g => g.GenreName)
                    .HasColumnName("genre_name");
                entity.Property(g => g.GenreDescription)
                    .HasColumnName("genre_description");
            });

            modelBuilder.Entity<LibraryBranch>(entity =>
            {
                entity.ToTable("library_branch");
                entity.Property(l => l.BranchId)
                    .HasColumnName("branch_id");
                entity.Property(l => l.BranchName)
                    .HasColumnName("branch_name");
                entity.Property(l => l.BranchLocation)
                    .HasColumnName("branch_location");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.ToTable("loan");
                entity.Property(l => l.LoanId)
                    .HasColumnName("loan_id");
                entity.Property(l => l.CopyId)
                    .HasColumnName("copy_id");
                entity.Property(l => l.PatronId)
                    .HasColumnName("patron_id");
                entity.Property(l => l.LoanStartDate)
                    .HasColumnName("loan_startdate");
                entity.Property(l => l.LoanEndDate)
                    .HasColumnName("loan_enddate");
            });

            modelBuilder.Entity<Patron>(entity =>
            {
                entity.ToTable("patron");
                entity.Property(pa => pa.PatronId)
                    .HasColumnName("patron_id");
                entity.Property(pa => pa.PatronFirstName)
                    .HasColumnName("patron_firstname");
                entity.Property(pa => pa.PatronLastName)
                    .HasColumnName("patron_lastname");
                entity.Property(pa => pa.PatronAddress)
                    .HasColumnName("patron_address");

            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.ToTable("publisher");
                entity.Property(p => p.PublisherId)
                    .HasColumnName("publisher_id");
                entity.Property(p => p.PublisherName)
                    .HasColumnName("publisher_name");
                entity.Property(p => p.PublisherLocation)
                    .HasColumnName("publisher_location");

            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.ToTable("staff");
                entity.Property(s => s.StaffId)
                    .HasColumnName("staff_id");
                entity.Property(s => s.BranchId)
                    .HasColumnName("branch_id");
                entity.Property(s => s.StaffFirstName)
                    .HasColumnName("staff_firstname");
                entity.Property(s => s.StaffLastName)
                    .HasColumnName("staff_lastname");
                entity.Property(s => s.StaffPosition)
                    .HasColumnName("staff_position");
                entity.Property(s => s.StaffSalary)
                    .HasColumnName("staff_salary");

            });
        }
        public DbSet<Author> Authors { get; set; }
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
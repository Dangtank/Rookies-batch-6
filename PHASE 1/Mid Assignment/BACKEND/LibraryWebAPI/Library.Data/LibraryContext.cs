using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Library.Data.Auth;
using Library.Data.Entities;

namespace Library.Data
{
    public class LibraryContextFactory : IDesignTimeDbContextFactory<LibraryContext>
    {
        public LibraryContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=LibraryDb;Integrated Security=True");

            return new LibraryContext(optionsBuilder.Options);
        }
    }

    public class LibraryContext : IdentityDbContext<ApplicationUser>
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region CategoryBook (many to many)

            modelBuilder.Entity<CategoryBook>()
                        .ToTable("CategoryBook")
                        .HasKey(t => new { t.BookId, t.CategoryId, t.RequestId });

            modelBuilder.Entity<CategoryBook>()
                        .HasOne(c => c.Category)
                        .WithMany(b => b.CategoryBooks)
                        .HasForeignKey(cb => cb.CategoryId);

            modelBuilder.Entity<CategoryBook>()
                        .HasOne(c => c.Book)
                        .WithMany(b => b.CategoryBooks)
                        .HasForeignKey(cb => cb.BookId);

            modelBuilder.Entity<CategoryBook>()
                        .HasOne(c => c.BookRequest)
                        .WithMany(b => b.CategoryBooks)
                        .HasForeignKey(cb => cb.RequestId);

            #endregion

            #region Category

            modelBuilder.Entity<Category>()
                            .ToTable("Category")//ten bang trong sql
                            .HasKey(cat => cat.CategoryId);//khoa chinh

            modelBuilder.Entity<Category>()
                            .Property(cat => cat.CategoryId)
                            .HasColumnName("CategoryId")
                            .HasColumnType("uniqueidentifier")
                            .IsRequired();

            modelBuilder.Entity<Category>()
                            .Property(cat => cat.CategoryName)
                            .HasColumnName("CategoryName")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(50);

            #endregion

            #region Book

            modelBuilder.Entity<Book>()
                            .ToTable("Book")
                            .HasKey(book => book.BookId);// Khoa chinh

            //  modelBuilder.Entity<Book>()
            //                .HasOne(b => b.BookRequestDetail)
            //              .WithOne(b => b.Book)
            //            .HasForeignKey<BookRequestDetail>(b => b.BookForeignKey);

            modelBuilder.Entity<Book>()
                            .Property(book => book.BookId)
                            .HasColumnName("BookId")
                            .HasColumnType("uniqueidentifier")
                            .IsRequired();

            modelBuilder.Entity<Book>()
                            .Property(book => book.BookName)
                            .HasColumnName("BookName")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(50);

            modelBuilder.Entity<Book>()
                            .Property(book => book.CategoryId)
                            .HasColumnName("CategoryId")
                            .HasColumnType("uniqueidentifier")
                            .IsRequired();

            modelBuilder.Entity<Book>()
                            .Property(book => book.CategoryName)
                            .HasColumnName("CategoryName")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(50);

            modelBuilder.Entity<Book>()
                           .Property(book => book.BorrowedBy)
                           .HasColumnName("BorrowedBy")
                           .HasColumnType("nvarchar")
                           .HasMaxLength(50);

            #endregion

            #region BookRequest

            modelBuilder.Entity<BookRequest>()
                            .ToTable("BookRequest")//ten bang trong sql
                            .HasKey(b => b.RequestId);//khoa chinh

            modelBuilder.Entity<BookRequest>()
                            .Property(b => b.RequestId)
                            .HasColumnName("RequestId")
                            .HasColumnType("uniqueidentifier")
                            .IsRequired();

            modelBuilder.Entity<BookRequest>()
                            .Property(b => b.RequestedBy)
                            .HasColumnName("RequestedBy")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(50);

            modelBuilder.Entity<BookRequest>()
                            .Property(b => b.RequestedDate)
                            .HasColumnName("RequestedDate")
                            .HasColumnType("datetime")
                            .HasMaxLength(50);

            modelBuilder.Entity<BookRequest>()
                            .Property(b => b.RequestStatus)
                            .HasColumnName("RequestStatus")
                            .HasColumnType("int")
                            .HasMaxLength(50);

            modelBuilder.Entity<BookRequest>()
                            .Property(b => b.RejectedBy)
                            .HasColumnName("RejectedBy")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(50);

            modelBuilder.Entity<BookRequest>()
                            .Property(b => b.ApprovedBy)
                            .HasColumnName("ApprovedBy")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(50);

            #endregion

            #region BookeRequestDetail

            modelBuilder.Entity<BookRequestDetail>()
                            .ToTable("BookRequestDetail")
                            .HasKey(book => book.DetailId);// Khoa chinh

            modelBuilder.Entity<BookRequestDetail>()
                            .HasOne<BookRequest>(s => s.BookRequest)//trong detail lay request 
                            .WithMany(g => g.BookRequestDetails)//1 request nay ket noi nhieu detail
                            .HasForeignKey(s => s.RequestForeignKey);

            modelBuilder.Entity<BookRequestDetail>()
                            .HasOne<Book>(s => s.Book)//trong detail lay book 
                            .WithMany(g => g.BookRequestDetails)//1 book nay ket noi nhieu detail
                            .HasForeignKey(s => s.BookForeignKey);

            // modelBuilder.Entity<BookBorrowingRequestDetail>()
            //                 .HasOne(s => s.Book)//trong detail lay book 
            //                 .WithOne(g => g.BookBorrowingRequestDetail)//1 book nay ket noi mot detail
            //                 .HasForeignKey<Book>(s => s.);

            modelBuilder.Entity<BookRequestDetail>()
                           .Property(book => book.DetailId)
                           .HasColumnName("DetailId")
                           .HasColumnType("uniqueidentifier")
                           .IsRequired();

            modelBuilder.Entity<BookRequestDetail>()
                           .Property(book => book.BookForeignKey)
                           .HasColumnName("BookForeignKey")
                           .HasColumnType("uniqueidentifier");

            // modelBuilder.Entity<BookBorrowingRequestDetail>()
            //                .Property(book => book.BookId)
            //                .HasColumnName("BookId")
            //                .HasColumnType("uniqueidentifier")
            //                .IsRequired();

            modelBuilder.Entity<BookRequestDetail>()
                            .Property(b => b.BookingDate)
                            .HasColumnName("BookingDate")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(50);

            modelBuilder.Entity<BookRequestDetail>()
                            .Property(b => b.ReturnDate)
                            .HasColumnName("ReturnDate")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(50);

            modelBuilder.Entity<BookRequestDetail>()
                            .Property(b => b.BorrowedBy)
                            .HasColumnName("BorrowedBy")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(50);

            modelBuilder.Entity<BookRequestDetail>()
                            .Property(b => b.BookName)
                            .HasColumnName("BookName")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(50);

            modelBuilder.Entity<BookRequestDetail>()
                            .Property(b => b.RequestForeignKey)
                            .HasColumnName("RequestForeignKey")
                            .HasColumnType("uniqueidentifier")
                            .HasMaxLength(50)
                            .IsRequired();

            #endregion

        }

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Book>? Books { get; set; }
        public DbSet<BookRequest> BookRequests { get; set; }
        public DbSet<BookRequestDetail> BookRequestDetails { get; set; }
        public DbSet<CategoryBook> CategoryBooks { get; set; }
    }
}

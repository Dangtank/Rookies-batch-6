using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Test.Data.Auth;
using Test.Data.Entities;

namespace Test.Data
{
    public class TestContextFactory : IDesignTimeDbContextFactory<TestContext>
    {
        public TestContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TestContext>();
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=LibraryDb;Integrated Security=True");

            return new TestContext(optionsBuilder.Options);
        }
    }

    public class TestContext : IdentityDbContext<ApplicationUser>
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
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

            modelBuilder.Entity<Book>()
                            .HasOne(b => b.BookRequestDetail)
                            .WithOne(b => b.Book)
                            .HasForeignKey<BookRequestDetail>(b => b.BookForeignKey);

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
                           .HasColumnType("uniqueidentifier")
                           .IsRequired();

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
                            .Property(b => b.RequestForeignKey)
                            .HasColumnName("RequestForeignKey")
                            .HasColumnType("uniqueidentifier")
                            .HasMaxLength(50)
                            .IsRequired();

            #endregion

        }

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Book>? Books { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<BookRequest> BookRequests { get; set; }
        public DbSet<BookRequestDetail> BookRequestDetails { get; set; }
        public DbSet<CategoryBook> CategoryBooks { get; set; }
    }
}

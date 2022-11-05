﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Test.Data.Auth;
using Test.Data.Entities;

namespace Test.Data
{
    public class TestContext : IdentityDbContext<ApplicationUser>
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
                            .HasOne<Category>(s => s.Category)//trong book lay category 
                            .WithMany(g => g.Books)//1 category nay ket noi nhieu book
                            .HasForeignKey(s => s.CategoryId);

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
                            .HasColumnType("uniqueidentifier");

            #endregion

            #region BookBorrowingRequest

            modelBuilder.Entity<BookBorrowingRequest>()
                                        .ToTable("BookBorrowingRequest")//ten bang trong sql
                                        .HasKey(b => b.RequestId);//khoa chinh

            modelBuilder.Entity<BookBorrowingRequest>()
                            .Property(b => b.RequestId)
                            .HasColumnName("RequestId")
                            .HasColumnType("uniqueidentifier")
                            .IsRequired();

            modelBuilder.Entity<BookBorrowingRequest>()
                            .Property(b => b.RequestedBy)
                            .HasColumnName("RequestedBy")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(50);

            modelBuilder.Entity<BookBorrowingRequest>()
                            .Property(b => b.RequestedDate)
                            .HasColumnName("RequestedDate")
                            .HasColumnType("datetime")
                            .HasMaxLength(50);

            modelBuilder.Entity<BookBorrowingRequest>()
                            .Property(b => b.RequestStatus)
                            .HasColumnName("RequestStatus")
                            .HasColumnType("int")
                            .HasMaxLength(50);

            modelBuilder.Entity<BookBorrowingRequest>()
                            .Property(b => b.RejectedBy)
                            .HasColumnName("RejectedBy")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(50);

            modelBuilder.Entity<BookBorrowingRequest>()
                            .Property(b => b.ApprovedBy)
                            .HasColumnName("ApprovedBy")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(50);

            #endregion

            #region BookeBorrowingRequestDetail

            modelBuilder.Entity<BookBorrowingRequestDetail>()
                                       .ToTable("Book")
                                       .HasKey(book => book.BookId);// Khoa chinh

            modelBuilder.Entity<BookBorrowingRequestDetail>()
                            .HasOne<BookBorrowingRequest>(s => s.BookeBorrowingRequest)//trong detail lay request 
                            .WithMany(g => g.BookBorrowingRequestDetails)//1 request nay ket noi nhieu detail
                            .HasForeignKey(s => s.RequestId);

            modelBuilder.Entity<BookBorrowingRequestDetail>()
                            .HasOne<Book>(s => s.Book)//trong detail lay book 
                            .WithOne(g => g.BookeBorrowingRequestDetail)//1 book nay ket noi mot detail
                            .HasForeignKey<Book>(s => s.BookId);

            modelBuilder.Entity<BookBorrowingRequestDetail>()
                           .Property(book => book.BookId)
                           .HasColumnName("BookId")
                           .HasColumnType("uniqueidentifier")
                           .IsRequired();

            modelBuilder.Entity<BookBorrowingRequestDetail>()
                            .Property(b => b.BookingDate)
                            .HasColumnName("BookingDate")
                            .HasColumnType("datetime")
                            .HasMaxLength(50);

            modelBuilder.Entity<BookBorrowingRequestDetail>()
                            .Property(b => b.BookingDate)
                            .HasColumnName("BookingDate")
                            .HasColumnType("datetime")
                            .HasMaxLength(50);

            modelBuilder.Entity<BookBorrowingRequestDetail>()
                            .Property(b => b.ReturnDate)
                            .HasColumnName("ReturnDate")
                            .HasColumnType("datetime")
                            .HasMaxLength(50);

            modelBuilder.Entity<BookBorrowingRequestDetail>()
                            .Property(b => b.RequestId)
                            .HasColumnName("RequestId")
                            .HasColumnType("uniqueidentifier")
                            .HasMaxLength(50);

            #endregion

        }

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Book>? Books { get; set; }
        public DbSet<BookBorrowingRequest> BookBorrowingRequests { get; set; }
        public DbSet<BookBorrowingRequestDetail> BookeBorrowingRequestDetails { get; set; }
        public DbSet<Person> People { get; set; }
    }
}

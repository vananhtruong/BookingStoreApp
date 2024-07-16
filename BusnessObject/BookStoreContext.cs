using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusnessObject;

public partial class BookStoreContext : DbContext
{
    public BookStoreContext()
    {
    }

    public BookStoreContext(DbContextOptions<BookStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookCategory> BookCategories { get; set; }

    public virtual DbSet<BookManagementMember> BookManagementMembers { get; set; }

    public virtual DbSet<OrderBook> OrderBooks { get; set; }

    public virtual DbSet<OrderBookDetail> OrderBookDetails { get; set; }

    private string GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();
        return configuration["ConnectionStrings:DefaultConnectionString"];
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString());
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Book__3DE0C20737968BE6");

            entity.ToTable("Book");

            entity.Property(e => e.Author).HasMaxLength(100);
            entity.Property(e => e.BookName).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 0)");

            entity.HasOne(d => d.BookCategory).WithMany(p => p.Books)
                .HasForeignKey(d => d.BookCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Book__BookCatego__3B75D760");
        });

        modelBuilder.Entity<BookCategory>(entity =>
        {
            entity.HasKey(e => e.BookCategoryId).HasName("PK__BookCate__6347EC0484CFB33F");

            entity.ToTable("BookCategory");

            entity.Property(e => e.BookCategoryName).HasMaxLength(100);
        });

        modelBuilder.Entity<BookManagementMember>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PK__BookMana__0CF04B18EDB0BA4B");

            entity.ToTable("BookManagementMember");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(80);
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        modelBuilder.Entity<OrderBook>(entity =>
        {
            entity.HasKey(e => e.OrderBookId).HasName("PK__OrderBoo__67BEEF30CE90FA19");

            entity.ToTable("OrderBook");

            entity.Property(e => e.OrderStatus).HasDefaultValue(false);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Member).WithMany(p => p.OrderBooks)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderBook__Membe__3F466844");
        });

        modelBuilder.Entity<OrderBookDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderBookId, e.BookId }).HasName("PK__OrderBoo__0460E31000939F76");

            entity.ToTable("OrderBookDetail");

            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Book).WithMany(p => p.OrderBookDetails)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderBook__BookI__4316F928");

            entity.HasOne(d => d.OrderBook).WithMany(p => p.OrderBookDetails)
                .HasForeignKey(d => d.OrderBookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderBook__Order__4222D4EF");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

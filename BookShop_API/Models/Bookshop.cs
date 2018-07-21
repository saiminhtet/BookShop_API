namespace BookShop_API.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Bookshop : DbContext
    {
        public Bookshop()
            : base("name=Bookshop")
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CreditCard> CreditCards { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<TransactionDetail> TransactionDetails { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.ISBN)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.Author)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<CreditCard>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<CreditCard>()
                .Property(e => e.CardNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Promotion>()
                .Property(e => e.Scope)
                .IsUnicode(false);

            modelBuilder.Entity<Promotion>()
                .Property(e => e.PromoItem)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.ShippingAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.PostalCode)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserType)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.ShippingAddress)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Passcode)
                .IsUnicode(false);
        }
    }
}

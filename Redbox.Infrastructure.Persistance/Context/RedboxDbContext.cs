using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Redbox.Core.Entities;
using System;

namespace Redbox.Infrastructure.Persistance.Context
{
    public class RedboxDbContext : DbContext
    {
        private const string DbName = "redbox.db";
        public string DbPath { get; }

        public RedboxDbContext(DbContextOptions<RedboxDbContext> options) : base(options)
        {
            string path = Environment.CurrentDirectory;
            DbPath = System.IO.Path.Join(path, DbName);
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<ItemDiscount> ItemDiscounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(e =>
            {
                e.HasKey(i => i.Id);
            });

            modelBuilder.Entity<Discount>(e =>
            {
                e.HasKey(d => d.Code);
                e.HasCheckConstraint(@$"CK_{nameof(Discount)}_{nameof(Discount.Percentage)}", @$"[{nameof(Discount.Percentage)}] > 0");
            });

            modelBuilder.Entity<ItemDiscount>(e =>
            {
                e.HasKey(id => new { id.ItemId, id.DiscountCode });
            });

            modelBuilder.Entity<Cart>(e =>
            {
                e.HasKey(c => c.Id);
            });

            modelBuilder.Entity<CartItem>(e =>
            {
                e.HasKey(ci => new { ci.CartId, ci.ItemId });
            });
        }
    }
}

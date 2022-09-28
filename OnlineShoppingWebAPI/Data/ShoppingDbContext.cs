using Microsoft.EntityFrameworkCore;
using OnlineShoppingWebAPI.Models;
using System.Collections.Generic;

namespace OnlineShoppingWebAPI.Data
{
    public class ShoppingDbContext : DbContext
    {
        public ShoppingDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<TransactionHistory> TransactionHistorys { get; set; }
    }
}

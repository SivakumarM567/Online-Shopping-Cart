using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class EshoppingZone2Context : DbContext
{
    public EshoppingZone2Context(DbContextOptions<EshoppingZone2Context> options) : base(options)
    {

    }
    
    public DbSet<Product>? ProductDetails { get; set; }
    
    public DbSet<Merchant>? MerchantDetails { get; set; }

    public DbSet<User>? UsersDetails { get; set; }

    public DbSet<Booking>? BookingDetails { get; set; }

    public DbSet<Payment>? PaymentDetails { get; set; }

}
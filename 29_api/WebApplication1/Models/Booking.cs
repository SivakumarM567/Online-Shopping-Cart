
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Booking
{
    [Key]
    public int BookedId { get; set; }

    public int? UserId { get; set; }

    public string? ProductName { get; set; }

    public int? TotalItem { get; set; }

    public int? Cost { get; set; }
}

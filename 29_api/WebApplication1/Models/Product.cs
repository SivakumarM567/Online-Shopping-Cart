using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Product
{
    [Key]
    public int ProductId { get; set; }

    public string? ProductName { get; set;}

    public string? Brand { get; set; }

    public string? Description { get; set; }

    public int? Cost { get; set; }
}
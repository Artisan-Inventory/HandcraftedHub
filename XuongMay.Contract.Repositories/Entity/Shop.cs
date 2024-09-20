using System.ComponentModel.DataAnnotations;

namespace XuongMay.Contract.Repositories.Entity;

public class Shop
{
    [MaxLength(255)] public required string ShopId { get; set; }
    [MaxLength(255)] public string? ShopName { get; set; }
    [MaxLength(255)] public string? Description { get; set; }
    public int Rating { get; set; }
    public required int UserId { get; set; }
    
    
    // Navigation properties
    public virtual ICollection<Product>? Products { get; set; } = new List<Product>();
    public virtual User? User { get; set; }
}
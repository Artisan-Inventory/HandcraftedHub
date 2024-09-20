using System.ComponentModel.DataAnnotations;

namespace XuongMay.Contract.Repositories.Entity;

public class Product
{
    [MaxLength(255)] public required string ProductId { get; set; }
    [MaxLength(255)] public string? ProductName { get; set; }
    [MaxLength(255)] public string? Description { get; set; }
    public float Price { get; set; }
    public int StockQuantity { get; set; }
    public required string CategoryId { get; set; }
    public required string ShopId { get; set; }
    
    // Navigation properties
    public virtual Category? Category { get; set; }
    public virtual Shop? Shop { get; set; }
}
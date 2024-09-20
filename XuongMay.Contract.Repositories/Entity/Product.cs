using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace XuongMay.Contract.Repositories.Entity;

public class Product
{
    [MaxLength(50)] public required string ProductId { get; set; }
    [MaxLength(255)] public string? ProductName { get; set; }
    [MaxLength(255)] public string? Description { get; set; }
    public float Price { get; set; }
    public int StockQuantity { get; set; }
    [MaxLength(50)] public required string CategoryId { get; set; }
    [MaxLength(50)] public required string ShopId { get; set; }

    // Navigation properties
    public virtual Category? Category { get; set; }
    public virtual Shop? Shop { get; set; }
    public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
    public virtual ICollection<Review>? Reviews { get; set; }
    public virtual ICollection<MediaUpload>? MediaUploads { get; set; }
}
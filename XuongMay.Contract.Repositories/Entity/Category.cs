using System.ComponentModel.DataAnnotations;

namespace XuongMay.Contract.Repositories.Entity;

public class Category
{
    [MaxLength(50)] public required string CategoryId { get; set; }
    [MaxLength(255)] public string? CategoryName { get; set; }
    [MaxLength(255)] public string? Description { get; set; }


    // Navigation properties
    public virtual ICollection<Product>? Products { get; set; } = new List<Product>();
}
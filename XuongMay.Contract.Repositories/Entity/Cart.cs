using System.ComponentModel.DataAnnotations;
using XuongMay.Repositories.Entity;

namespace XuongMay.Contract.Repositories.Entity;

public class Cart
{
    [MaxLength(50)] public required string CartId { get; set; }
    [MaxLength(50)] public required string ProductId { get; set; }
    [MaxLength(50)] public required Guid UserId { get; set; }
    public int ProductQuantity { get; set; }
    
    
    // Navigation properties
    public virtual ApplicationUser? User { get; set; }
}
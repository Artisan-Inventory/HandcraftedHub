using System.ComponentModel.DataAnnotations;

namespace XuongMay.Contract.Repositories.Entity;

public class OrderDetail
{
    [MaxLength(255)] public required string OrderDetailId { get; set; }
    public required string OrderId { get; set; }
    public string? Address { get; set; }
    public string? CustomerName { get; set; }
    public string? Phone { get; set; }
    public string? Note { get; set; }
    public required string CancleReasonId { get; set; }
    public required string ProductId { get; set; }
    public int ProductQuantity { get; set; }
    public float ProductPrice { get; set; }
    
    
    // Navigation properties
    public virtual Order? Order { get; set; }
    public virtual Product? Product { get; set; }
    public virtual CancleReason? CancleReason { get; set; }
    
}
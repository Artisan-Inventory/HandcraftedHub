using System.ComponentModel.DataAnnotations;

namespace XuongMay.Contract.Repositories.Entity;

public class OrderDetail
{
    [MaxLength(50)] public required string OrderDetailId { get; set; }
    [MaxLength(50)] public required string OrderId { get; set; }
    [MaxLength(255)] public string? Address { get; set; }
    [MaxLength(255)] public string? CustomerName { get; set; }
    [MaxLength(15)] public string? Phone { get; set; }
    [MaxLength(255)] public string? Note { get; set; }
    [MaxLength(50)] public required string CancleReasonId { get; set; }
    [MaxLength(50)] public required string ProductId { get; set; }
    public int ProductQuantity { get; set; }
    public float ProductPrice { get; set; }


    // Navigation properties
    public virtual Order? Order { get; set; }
    public virtual Product? Product { get; set; }
    public virtual CancelReason? CancelReason { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace XuongMay.Contract.Repositories.Entity;

public class Payment
{
    [MaxLength(50)] public required string PaymentId { get; set; }
    [MaxLength(50)] public required string OrderId { get; set; }
    public DateTime CreateDateTime { get; set; }
    public DateTime ExpirationDateTime { get; set; }
    public float TotalAmount { get; set; }
    [MaxLength(50)] public required string PaymentDetailId { get; set; }
    
    
    // Navigation properties
    public virtual Order? Order { get; set; }
    public virtual ICollection<PaymentDetail>? PaymentDetails { get; set; }
}
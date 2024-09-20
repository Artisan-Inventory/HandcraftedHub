using System.ComponentModel.DataAnnotations;

namespace XuongMay.Contract.Repositories.Entity;

public class PaymentDetail
{
    [MaxLength(255)] public required string PaymentDetailId { get; set; }
    [MaxLength(255)] public required string PaymentId { get; set; }
    [MaxLength(255)] public string? Status { get; set; }
    public float Amount { get; set; }
    [MaxLength(255)] public string? Method { get; set; }
    [MaxLength(255)] public string? ExternalTransactionCode { get; set; }
    
    // Navigation properties
    public virtual Payment? Payment { get; set; }
    
}
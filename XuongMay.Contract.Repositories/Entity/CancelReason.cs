using System.ComponentModel.DataAnnotations;

namespace XuongMay.Contract.Repositories.Entity;

public class CancelReason
{
    [MaxLength(50)] public required string CancelReasonId { get; set; } 
    [MaxLength(50)] public required string OrderDetailId { get; set; }
    [MaxLength(255)] public string? Description { get; set; }
    public float RefundRate { get; set; }

    // Navigation properties
    public virtual OrderDetail? OrderDetail { get; set; }
}
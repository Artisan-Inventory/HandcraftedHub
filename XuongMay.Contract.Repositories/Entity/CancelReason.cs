namespace XuongMay.Contract.Repositories.Entity;

public class CancelReason
{
    public required string CancelReasonId { get; set; }
    public string? Description { get; set; }
    public float RefundRate { get; set; }
    
}
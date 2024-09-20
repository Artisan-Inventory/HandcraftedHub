using System.ComponentModel.DataAnnotations;

namespace XuongMay.Contract.Repositories.Entity;

public class StatusChange
{
    [MaxLength(50)] public required string StatusChangeId { get; set; }
    [MaxLength(50)] public required string OrderId { get; set; }
    public DateTime ChangeTime { get; set; }
    [MaxLength(255)] public string? Status { get; set; }
    
    // Navigation properties
    public virtual Order? Order { get; set; }
}
using System.ComponentModel.DataAnnotations;
using XuongMay.Repositories.Entity;

namespace XuongMay.Contract.Repositories.Entity;

public class Order
{
    [MaxLength(50)] public required string OrderId { get; set; }
    [MaxLength(50)] public required string PaymentId { get; set; }
    [MaxLength(50)] public required Guid UserId { get; set; }
    public DateTime OrderDate { get; set; }
    [MaxLength(50)] public string? CurrentStatus { get; set; }

    // Navigation properties
    public virtual Account? Account { get; set; }
    public virtual Payment? Payment { get; set; }
    public virtual ApplicationUser? User { get; set; }
    public virtual ICollection<StatusChange>? StatusChanges { get; set; }
    public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
}
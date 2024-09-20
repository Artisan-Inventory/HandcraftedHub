using System.ComponentModel.DataAnnotations;

namespace XuongMay.Contract.Repositories.Entity;

public class Order
{
    public required string OrderId { get; set; }
    public required string PaymentId { get; set; }
    public float TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
    [MaxLength(50)]
    public string? CurrentStatus { get; set; }
    
    // Navigation properties
    public virtual Account? Account { get; set; }
    public virtual Payment? Payment { get; set; }
}
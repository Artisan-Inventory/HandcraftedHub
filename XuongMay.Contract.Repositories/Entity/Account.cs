using System.ComponentModel.DataAnnotations;

namespace XuongMay.Contract.Repositories.Entity;

public class Account
{
    [MaxLength(50)] public required string AccountId { get; set; }
    [MaxLength(255)] public string? FullName { get; set; }
    [MaxLength(15)] public string? Phone { get; set; }
    [EmailAddress] public string? Email { get; set; }
    [MaxLength(255)] public string? Address { get; set; }
    [MaxLength(100)] public string? Password { get; set; }
    [MaxLength(100)] public string? Role { get; set; }
    public Boolean Status { get; set; }

    // Navigation properties
    public virtual ICollection<Order>? Orders { get; set; } = new List<Order>();

    public virtual ICollection<Review>? Reviews { get; set; } = new List<Review>();
}
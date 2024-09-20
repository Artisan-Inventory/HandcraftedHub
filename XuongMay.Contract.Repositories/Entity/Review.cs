using System.ComponentModel.DataAnnotations;
using XuongMay.Repositories.Entity;

namespace XuongMay.Contract.Repositories.Entity;

public class Review
{
    [MaxLength(50)] public required string ReviewId { get; set; }
    [MaxLength(50)] public required string ProductId { get; set; }
    [MaxLength(50)] public required Guid UserId { get; set; }
    [MaxLength(50)] public required string ReplyId { get; set; }
    [MaxLength(255)] public string? Content { get; set; }
    public int Rating { get; set; }
    public DateTime Date { get; set; }


    // Navigation properties
    public virtual Account? Account { get; set; }
    public virtual Product? Product { get; set; }
    public virtual ApplicationUser? User { get; set; }
    public virtual Reply? Reply { get; set; }
}
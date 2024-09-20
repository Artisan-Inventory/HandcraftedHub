using System.ComponentModel.DataAnnotations;

namespace XuongMay.Contract.Repositories.Entity;

public class Reply
{
    [MaxLength(50)] public required string ReplyId { get; set; }
    [MaxLength(50)] public required string ReviewId { get; set; }
    [MaxLength(50)] public required string ShopId { get; set; }
    [MaxLength(255)] public string? Content { get; set; }
    public DateTime Date { get; set; }
    
    // Navigation properties
    public virtual Review? Review { get; set; }
    public virtual Shop? Shop { get; set; }
}
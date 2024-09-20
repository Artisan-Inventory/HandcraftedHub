using System.ComponentModel.DataAnnotations;
using XuongMay.Repositories.Entity;

namespace XuongMay.Contract.Repositories.Entity;

public class MediaUpload
{
    [MaxLength(50)] public required string MediaUploadId { get; set; }
    [MaxLength(50)] public required string UserId { get; set; }
    [MaxLength(255)] public string? Url { get; set; }
    public Boolean IsMain { get; set; }
    [MaxLength(50)] public required string ProductId { get; set; }

    // Navigation properties
    // public virtual User? User { get; set; }
    public virtual Product? Product { get; set; }
    public virtual ApplicationUser? User { get; set; }
}
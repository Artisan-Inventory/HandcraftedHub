using System.ComponentModel.DataAnnotations;

namespace XuongMay.Contract.Repositories.Entity;

public class Review
{
    [MaxLength(255)]
    public required string ReviewId { get; set; }
    [MaxLength(255)]
    public string? Content { get; set; }
    public int Rating { get; set; }
    public DateTime Date { get; set; }
    
    
    // Navigation properties
    public virtual Account? Account { get; set; }
    public virtual Product? Product { get; set; }
}
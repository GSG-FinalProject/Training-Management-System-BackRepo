namespace TMS.Domain.Entities;
public class Trainer : User
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
namespace TMS.Domain.Entities;
public class Admin : User
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

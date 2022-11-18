using Company.Framework.Entity;

namespace Company.Crm.Domain.Entities;

public class Phone : BaseEntity
{
    public int UserId { get; set; }
    public string? PhoneNumber { get; set; }
    public int PhoneType { get; set; }
}
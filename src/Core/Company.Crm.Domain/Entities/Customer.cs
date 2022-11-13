using Company.Framework.Entity;

namespace Company.Crm.Domain.Entities;

//[Table("Customer")]
public class Customer : BaseEntity
{
    public int UserId { get; set; }
    public string? IdentityNumber { get; set; }
    public int? GenderId { get; set; }
    public int? TitleId { get; set; }
    public string? CompanyName { get; set; }
    public int? StatusTypeId { get; set; }
    public int? RegionId { get; set; }
    public DateTime? BirthDate { get; set; }
}
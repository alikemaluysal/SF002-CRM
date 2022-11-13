using Company.Framework.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Company.Crm.Application.Dtos;

public class CreateOrUpdateCustomerDto : BaseDto
{
    [Required]
    public int UserId { get; set; }
    public string? IdentityNumber { get; set; }
    public int? GenderId { get; set; }
    public int? TitleId { get; set; }

    [Required]
    [StringLength(50)]
    public string CompanyName { get; set; }
    public int? StatusTypeId { get; set; }
    public int? RegionId { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }
}
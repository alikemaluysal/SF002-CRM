using Company.Framework.Dtos;

namespace Company.Crm.Application.Dtos;

public class CustomerDto : BaseDto
{
    public int UserId { get; set; }
    public int? GenderId { get; set; }
    public string? GenderName { get; set; }
    public int? TitleId { get; set; }
    public string? TitleName { get; set; }
    public string? CompanyName { get; set; }
}
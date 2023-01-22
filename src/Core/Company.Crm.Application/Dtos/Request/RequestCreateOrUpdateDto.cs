using Company.Framework.Dtos;

namespace Company.Crm.Application.Dtos.Notification;

public class RequestCreateOrUpdateDto : BaseDto
{
    public int CustomerUserId { get; set; }
    public int EmployeeUserId { get; set; }
    public int RequestStatusId { get; set; }
    public string Description { get; set; }
}
using Company.Framework.Entity;

namespace Company.Crm.Domain.Entities;

public class Task : BaseEntity
{
    public int RequestId { get; set; }
    public int EmployeeUserId { get; set; }
    public DateTime TaskStartDate { get; set; }
    public DateTime TaskEndDate { get; set; }
    public string Description { get; set; }
    public int TaskStatusId { get; set; }
}
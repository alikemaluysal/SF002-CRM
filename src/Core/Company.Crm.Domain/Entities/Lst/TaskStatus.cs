using Company.Framework.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Crm.Domain.Entities.Lst;
[Table("TaskStatus", Schema = "LST")]

public class TaskStatus : BaseEntity
{
    public string? Name { get; set; }

    public static bool Delete(TaskStatus entity)
    {
        throw new NotImplementedException();
    }
}

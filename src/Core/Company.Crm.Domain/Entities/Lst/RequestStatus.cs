using Company.Framework.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Crm.Domain.Entities.Lst;

[Table("RequestStatus", Schema = "LST")]

public class RequestStatus : BaseEntity
{
    public string Name { get; set; }
}

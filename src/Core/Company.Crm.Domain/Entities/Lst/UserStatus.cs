using Company.Framework.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Crm.Domain.Entities.Lst;

[Table("UserStatus", Schema = "LST")]
public class UserStatus : BaseEntity
{
    public string Name { get; set; }
}
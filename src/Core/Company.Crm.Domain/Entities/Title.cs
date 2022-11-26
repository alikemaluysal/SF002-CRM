using Company.Framework.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Crm.Domain.Entities;

[Table("Title", Schema = "LST")]
public class Title : BaseEntity
{
    public string Name { get; set; }
}
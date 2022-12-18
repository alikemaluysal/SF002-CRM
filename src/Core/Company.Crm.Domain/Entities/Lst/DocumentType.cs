using Company.Framework.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Crm.Domain.Entities.Lst;
[Table("DocumentType", Schema = "LST")]
public class DocumentType : BaseEntity
{
    public string? Name { get; set; }
}

using Company.Framework.Entity;

namespace Company.Crm.Domain.Entities;

public class Region : BaseEntity
{
    public string Name { get; set; }
    public int ParentId { get; set; }
}
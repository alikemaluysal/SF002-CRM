using Company.Framework.Entity;

namespace Company.Crm.Domain.Entities;

public class Region : BaseEntity, IEntity
{
    public string Name { get; set; }
    public int ParentId { get; set; }
}
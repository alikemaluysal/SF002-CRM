using Company.Framework.Entity;

namespace Company.Crm.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}

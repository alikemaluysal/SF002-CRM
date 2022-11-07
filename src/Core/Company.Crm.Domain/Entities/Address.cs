using Company.Crm.Domain.Enums;
using Company.Framework.Entity;

namespace Company.Crm.Domain.Entities
{
    public class Address : BaseEntity
    {
        public int UserId { get; set; }

        //prop, entity ismiyle aynı olamıyor?
        public string Description { get; set; }        
        public AddressTypeEnum AddressType { get; set; }
    }
}

using Company.Framework.Entity;

namespace Company.Crm.Domain.Entities
{
    public class Offers : BaseEntity
    {
        public int RequestId { get; set; }
        public int EmployeeUserId { get; set; }
        public DateTime? OfferDate { get; set; }
        public int? BidAmount { get; set; }
    }
}

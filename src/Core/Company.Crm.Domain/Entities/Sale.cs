using Company.Framework.Entity;

namespace Company.Crm.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public int OfferId { get; set; }
        public float Price { get; set; }
        public DateTime SaleConfirmationDate { get; set; }
        public bool IsCompleted { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Offer Offer { get; set; }
    }
}

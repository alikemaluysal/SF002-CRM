using Company.Framework.Entity;

namespace Company.Crm.Domain.Entities;

public class StatusType : BaseEntity
{
    public string Name { get; set; }

    #region Navigations

    public List<Customer> Customers { get; set; }

    #endregion
}
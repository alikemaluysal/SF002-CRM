using System.ComponentModel.DataAnnotations.Schema;
using Company.Framework.Entity;

namespace Company.Crm.Domain.Entities;

[Table("StatusType", Schema = "LST")]
public class StatusType : BaseEntity
{
    public string Name { get; set; }

    #region Navigations

    public List<Customer> Customers { get; set; }

    #endregion
}
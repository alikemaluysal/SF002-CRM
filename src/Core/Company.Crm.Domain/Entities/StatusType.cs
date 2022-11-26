using Company.Framework.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Crm.Domain.Entities;

[Table("StatusType", Schema = "LST")]
public class StatusType : BaseEntity
{
    public string Name { get; set; }

    #region Navigations

    public List<Customer> Customers { get; set; }

    #endregion
}
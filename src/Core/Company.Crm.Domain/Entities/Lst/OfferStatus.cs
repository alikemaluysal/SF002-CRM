using Company.Framework.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Crm.Domain.Entities.Lst;

[Table("OfferStatus", Schema = "LST")]
public class OfferStatus : BaseEntity
{
    public string Name { get; set; }
}
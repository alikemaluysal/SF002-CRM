using System.ComponentModel.DataAnnotations.Schema;
using Company.Crm.Domain.Entities.Lst;
using Company.Crm.Domain.Enums;
using Company.Framework.Entity;

namespace Company.Crm.Domain.Entities;

public class Customer : BaseEntity
{
    public int UserId { get; set; }
    public string? IdentityNumber { get; set; }
    public int? GenderId { get; set; }
    public int? TitleId { get; set; }
    public string? CompanyName { get; set; }
    public int? StatusTypeId { get; set; }
    public CustomerTypeEnum CustomerType { get; set; }
    public int? RegionId { get; set; }
    public DateTime BirthDate { get; set; }

    #region Navigation Properties

    [ForeignKey("StatusTypeId")]
    public StatusType? StatusTypeFk { get; set; }

    #endregion
}
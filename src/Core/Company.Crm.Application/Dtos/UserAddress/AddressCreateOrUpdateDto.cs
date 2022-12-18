using System.ComponentModel.DataAnnotations.Schema;
using Company.Framework.Dtos;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Company.Crm.Application.Dtos.UserAddress;

public class UserPhoneCreateOrUpdateDto : BaseDto
{
    public UserPhoneCreateOrUpdateDto()
    {
        UserPhoneTypes = new List<SelectListItem>();
    }

    public int UserId { get; set; }
    public string Description { get; set; }
    public int AddressTypeEnumNumber { get; set; }

    [NotMapped]
    [ValidateNever]
    public List<SelectListItem>? UserPhoneTypes { get; set; }
}
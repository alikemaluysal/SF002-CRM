using Company.Framework.Dtos;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Crm.Application.Dtos.Address
{
    public class AddressCreateOrUpdateDto : BaseDto
    {
        public AddressCreateOrUpdateDto()
        {
            AddressTypes = new List<SelectListItem>();
        }
        public int UserId { get; set; }
        public string Description { get; set; }
        public int AddressTypeEnumNumber { get; set; }

        [NotMapped, ValidateNever]
        public List<SelectListItem>? AddressTypes { get; set; }
    }
}

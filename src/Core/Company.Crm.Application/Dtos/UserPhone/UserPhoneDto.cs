using Company.Framework.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Crm.Application.Dtos.UserPhone
{
    public class UserPhoneDto : BaseDto
    {
        public int UserId { get; set; }
        public string? PhoneNumber { get; set; }
        public int PhoneType { get; set; }
    }
}


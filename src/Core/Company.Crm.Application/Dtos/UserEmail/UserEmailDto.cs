using Company.Crm.Domain.Enums;
using Company.Framework.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Crm.Application.Dtos.UserEmail
{
    public class UserEmailDto : BaseDto
    {
        public int UserId { get; set; }
        public string EmailAddress { get; set; }
        public string EmailType { get; set; }
    }
}


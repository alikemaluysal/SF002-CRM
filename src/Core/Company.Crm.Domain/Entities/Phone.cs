using Company.Framework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Crm.Domain.Entities
{
    public class Phone : BaseEntity
    {
        public int UserId { get; set; } 
        public string? PhoneNumber { get; set; }
        public int PhoneType { get; set; }





    }
}

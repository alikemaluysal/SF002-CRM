using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Framework.Entity;

namespace Company.Crm.Domain.Entities
{
    public class Department :BaseEntity ,IEntity
    {
        [Display(Name="DEPARTMAN ADI")]
        public  string? Name { get; set; }
    }
}

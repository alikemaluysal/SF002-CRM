using Company.Framework.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Crm.Domain.Entities
{
    public class Title : BaseEntity
    {
        public string Name { get; set; }
    }
}

using Company.Framework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Crm.Domain.Entities
{
    public class OfferStatus:BaseEntity,IEntity
    {
        public string Name { get; set; }
    }
}

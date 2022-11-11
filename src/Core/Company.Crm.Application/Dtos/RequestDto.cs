using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Crm.Application.Dtos
{
    public class RequestDto
    {
        public int CustomerUserId { get; set; }
        public int EmployeeUserId { get; set; }
        public int RequestStatusId { get; set; }
        public string Description { get; set; }
        public OfferDto offerDto { get; set; }
        //public SalesDto salesDto { get; set; }
    }
}

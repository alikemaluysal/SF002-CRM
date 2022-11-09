using Company.Framework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Crm.Domain.Entities
{
    public class Task : BaseEntity
    {
        public int RequestId { get; set; }
        public int EmployeeUserId { get; set; }
        public DateTime TaskStartDate { get; set; }
        public DateTime TaskEndDate { get; set; }
        public string Description { get; set; }
        public int TaskStatusId { get; set; }
    }
}

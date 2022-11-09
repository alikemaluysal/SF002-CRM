using Company.Crm.Domain.Entities;
using Company.Framework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Company.Crm.Domain.Entities.Task;

namespace Company.Crm.Domain.Repositories
{
    public interface ITaskRepository : IRepository<Task>
    {
    }
}

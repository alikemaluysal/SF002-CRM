using Company.Crm.Domain.Repositories;
using Company.Framework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task = Company.Crm.Domain.Entities.Task;

namespace Company.Crm.Entityframework.Repositories
{
    public class TaskRepository : BaseRepository<AppDbContext, Task>, ITaskRepository
    {
        public TaskRepository(AppDbContext context) : base(context)
        {
        }
    }
}

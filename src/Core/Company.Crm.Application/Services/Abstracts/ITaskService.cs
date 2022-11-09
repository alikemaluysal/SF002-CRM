using Company.Crm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Company.Crm.Domain.Entities.Task;

namespace Company.Crm.Application.Services.Abstracts
{
    public interface ITaskService
    {
        public List<Task> GetAll();
        public Task? GetById(int id);
        public bool Insert(Task entity);
        public bool Update(Task entity);
        public bool Delete(Task entity);
        public bool DeleteById(int id);
    }
}

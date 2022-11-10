using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Crm.Domain.Entities;

namespace Company.Crm.Application.Services.Abstracts
{
    public interface IDepartmentService
    {
        public List<Department> GetAll();
        public Department? GetById(int id);
        public bool Insert(Department entity);
        public bool Update(Department entity);
        public bool Delete(Department entity);
        public bool DeleteById(int id);
    }
}

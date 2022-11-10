using Company.Crm.Application.Dtos;
using Company.Crm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Crm.Application.Services.Abstracts
{
    public interface IStatusTypeService
    {
        public List<StatusType> GetAll();
        public StatusType? GetById(int id);
        public bool Insert(StatusType entity);
        public bool Update(StatusType entity);
        public bool Delete(StatusType entity);
        public bool DeleteById(int id);
    }
}

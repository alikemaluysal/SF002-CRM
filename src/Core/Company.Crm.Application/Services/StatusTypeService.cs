using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Crm.Application.Services
{
    public class StatusTypeService : IStatusTypeService
    {
        private readonly IStatusTypeRepository _statusTypeRepository;

        public StatusTypeService(IStatusTypeRepository statusTypeRepository)
        {
            _statusTypeRepository = statusTypeRepository;
        }

        public bool Delete(StatusType entity)
        {
            return _statusTypeRepository.Delete(entity);
        }

        public bool DeleteById(int id)
        {
            return _statusTypeRepository.DeleteById(id);
        }

        public List<StatusType> GetAll()
        {
            return _statusTypeRepository.GetAll();
        }

        public StatusType? GetById(int id)
        {
            return _statusTypeRepository.GetById(id);
        }

        public bool Insert(StatusType entity)
        {
            return _statusTypeRepository.Insert(entity);
        }

        public bool Update(StatusType entity)
        {
            return _statusTypeRepository.Update(entity);
        }
    }
}

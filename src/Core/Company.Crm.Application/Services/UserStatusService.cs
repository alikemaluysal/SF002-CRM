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
    public class UserStatusService : IUserStatusService
    {
        private readonly IUserStatusRepository _userStatusesRepository;

        public UserStatusService(IUserStatusRepository userStatusesRepository)
        {
            _userStatusesRepository = userStatusesRepository;
        }

        public bool Delete(UserStatus entity)
        {
            return _userStatusesRepository.Delete(entity);
        }

        public bool DeleteById(int id)
        {
            return _userStatusesRepository.DeleteById(id);
        }

        public List<UserStatus> GetAll()
        {
            return _userStatusesRepository.GetAll().ToList();
        }

        public UserStatus? GetById(int id)
        {
            return _userStatusesRepository.GetById(id);
        }

        public bool Insert(UserStatus entity)
        {
            return _userStatusesRepository.Insert(entity);


        }

        public bool Update(UserStatus entity)
        {
            return _userStatusesRepository.Update(entity);
        }
    }
}

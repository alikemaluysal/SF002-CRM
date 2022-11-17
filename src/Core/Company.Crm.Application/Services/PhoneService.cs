using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;


namespace Company.Crm.Application.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneRepository _phoneRepository;

        public PhoneService(IPhoneRepository phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }

        public List<Phone> GetAll()
        {
            return _phoneRepository.GetAll().ToList();
        }

        public Phone? GetById(int id)
        {
            return _phoneRepository.GetById(id);
        }

        public bool Insert(Phone entity)
        {
            return _phoneRepository.Insert(entity);
        }

        public bool Update(Phone entity)
        {
            return _phoneRepository.Update(entity);
        }

        public bool Delete(Phone entity)
        {
            return _phoneRepository.Delete(entity);
        }

        public bool DeleteById(int id)
        {
            return _phoneRepository.DeleteById(id);
        }
    }
}
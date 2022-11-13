using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;
using Company.Crm.Entityframework.Repositories;
using System.Text;
using System.Threading.Tasks;

namespace Company.Crm.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository _emailRepository;

        public EmailService(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }

        List<Email> IEmailService.GetAll()
        {
            return _emailRepository.GetAll();
        }

        public Email? GetById(int id)
        {
            return _emailRepository.GetById(id);
        }

        public bool Insert(Email entity)
        {
            return _emailRepository.Insert(entity);
        }

        public bool Update(Email entity)
        {
            return _emailRepository.Update(entity);
        }

        public bool Delete(Email entity)
        {
            return _emailRepository.Delete(entity);
        }

        public bool DeleteById(int id)
        {
            return _emailRepository.DeleteById(id);
        }

       
    }
}

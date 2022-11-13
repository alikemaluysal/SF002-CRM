using Company.Crm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Crm.Application.Services.Abstracts
{
    public interface IEmailService
    {
        public List<Email> GetAll();
        public Email? GetById(int id);
        public bool Insert(Email entity);
        public bool Update(Email entity);
        public bool Delete(Email entity);
        public bool DeleteById(int id);
    }
}

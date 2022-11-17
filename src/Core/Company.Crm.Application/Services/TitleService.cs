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
    public class TitleService : ITitleService
    {
        private readonly ITitleRepository _titleRepository;

        public TitleService(ITitleRepository titleRepository)
        {
            _titleRepository = titleRepository;
        }

        public List<Title> GetAll()
        {
            return _titleRepository.GetAll();
        }

        public Title GetById(int id)
        {
            return _titleRepository.GetById(id);
        }

        public bool Insert(Title entity)
        {
            return _titleRepository.Insert(entity);
        }

        public bool Update(Title entity)
        {
            return _titleRepository.Update(entity);
        }

        public bool Delete(Title entity)
        {
            return _titleRepository.Delete(entity);
        }
        public bool DeleteById(int id)
        {
            return _titleRepository.DeleteById(id);
        }

    }
}

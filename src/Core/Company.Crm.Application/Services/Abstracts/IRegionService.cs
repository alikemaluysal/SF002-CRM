using Company.Crm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Crm.Application.Services.Abstracts
{
    public interface IRegionService
    {
        public List<Region> GetAll();
        public Region? GetById(int id);
        public bool Insert(Region entity);
        public bool Update(Region entity);
        public bool Delete(Region entity);
        public bool DeleteById(int id);
    }
}

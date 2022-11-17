using Company.Crm.Domain.Entities;
using Company.Framework.Entity;
using Company.Framework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Crm.Domain.Repositories
{
    public interface ITitleRepository : IRepository<Title>
    {
        public List<Title> GetAll();
        public Title? GetById(int id);
        public bool Insert(Title entity);
        public bool Update(Title entity);
        public bool Delete(Title entity);
        public bool DeleteById(int id);

    }


}

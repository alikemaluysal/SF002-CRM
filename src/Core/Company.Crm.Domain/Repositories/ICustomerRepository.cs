﻿using Company.Crm.Domain.Entities;
using Company.Framework.Repository;

namespace Company.Crm.Domain.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        public List<Customer> GetAllByRegionId(int regionId);
    }
}

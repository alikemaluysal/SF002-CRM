﻿using Company.Crm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Crm.Application.Services.Abstracts
{
    public interface IAddressService
    {
        public List<Address> GetAll();
        public Address? GetById(int id);
        public bool Insert(Address entity);
        public bool Update(Address entity);
        public bool Delete(Address entity);
        public bool DeleteById(int id);
    }
}

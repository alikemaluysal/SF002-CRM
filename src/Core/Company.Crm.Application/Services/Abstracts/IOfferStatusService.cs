﻿using Company.Crm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Crm.Application.Services.Abstracts
{
    public interface IOfferStatusService
    {
        public List<OfferStatus> GetAll();
        public OfferStatus? GetById(int id);
        public bool Insert(OfferStatus entity);
        public bool Update(OfferStatus entity);
        public bool Delete(OfferStatus entity);
        public bool DeleteById(int id);
        
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;
using Company.Framework.Repository;

namespace Company.Crm.Entityframework.Repositories
{
    public class DepartmentRepository :BaseRepository<AppDbContext,Department>,IDepartmentRepository
    {
        private readonly AppDbContext _ctx;
        public DepartmentRepository(AppDbContext ctx): base(ctx)
        {
            _ctx=ctx;
        }

    }
}

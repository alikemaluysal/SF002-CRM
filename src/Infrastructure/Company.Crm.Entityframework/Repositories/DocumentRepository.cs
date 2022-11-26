﻿using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;
using Company.Framework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Crm.Entityframework.Repositories
{
    public class DocumentRepository : BaseRepository<AppDbContext,Document> , IDocumentRepository
    {
        readonly AppDbContext _context;
        public DocumentRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _context = appDbContext;
        }
    }
}
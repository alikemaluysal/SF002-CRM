using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;
using Company.Framework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Crm.Entityframework
{
    public class TitleRepository : BaseRepository<AppDbContext, Title>, ITitleRepository
    {
        private readonly AppDbContext _ctx;
        public TitleRepository(AppDbContext context) : base(context)
        {
            _ctx = context;
        }
    }
}

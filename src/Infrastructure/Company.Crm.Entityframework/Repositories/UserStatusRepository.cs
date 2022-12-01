using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;
using Company.Framework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Crm.Entityframework.Repositories
{
    public class UserStatusRepository : BaseRepository<AppDbContext, UserStatus>, IUserStatusRepository
    {
        private readonly AppDbContext _ctx;
        public UserStatusRepository(AppDbContext context) : base(context)
        {
            _ctx = context;
        }
    }
}

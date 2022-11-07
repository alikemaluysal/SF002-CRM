using Company.Crm.Domain.Entities;
using Company.Framework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Crm.Domain.Repositories
{
    public interface INotificationRepository : IRepository<Notification>
    {
    }
}

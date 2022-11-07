﻿using Company.Framework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Crm.Domain.Entities
{
    public class Notification : BaseEntity, IEntity
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool IsRead { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

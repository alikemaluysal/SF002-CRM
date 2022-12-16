using Company.Crm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Crm.Entityframework.EntityConfigurations
{
    public class UserStatusConfiguration : IEntityTypeConfiguration<UserStatus>
    {
        public void Configure(EntityTypeBuilder<UserStatus> builder)
        {
            
            builder.Property(z => z.Id).IsRequired();
            builder.Property(z => z.Name).IsRequired().HasMaxLength(50);
        }
    }
}

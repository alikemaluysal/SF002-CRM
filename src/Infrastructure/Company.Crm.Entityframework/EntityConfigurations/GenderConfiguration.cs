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
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).HasMaxLength(50);
        }
    }
}

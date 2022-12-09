using Company.Crm.Domain.Entities.Lst;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Crm.Entityframework.EntityConfigurations
{

    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {

        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(150);
            builder.Property(c => c.ParentId).UseIdentityColumn();

        }
    }

}

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
    public class OfferStatusConfiguration : IEntityTypeConfiguration<OfferStatus>
    {
        public void Configure(EntityTypeBuilder<OfferStatus> builder)
        {
            builder.Property(o => o.Id).IsRequired();
            builder.Property(o => o.Name).HasMaxLength(50);
            
        }
    }
}

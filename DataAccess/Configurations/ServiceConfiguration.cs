using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    internal class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(50);
            builder.Property(x =>x.Description).HasMaxLength(500);
            builder.Property(x => x.Deleted).HasDefaultValue<int>(0);

            builder.HasIndex(x => new { x.Title, x.Deleted})
                   .HasDatabaseName("idx_Service_Title_Deleted");

        }
    }
}

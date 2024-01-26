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
    internal class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(50);
            builder.Property(x =>x.LastName).HasMaxLength(50);
            builder.Property(x => x.Deleted).HasDefaultValue<int>(0);


            builder.HasIndex(x => new { x.FirstName, x.LastName })
                   .HasDatabaseName("idx_Person_FirstName_LastName");
        }
    }
}

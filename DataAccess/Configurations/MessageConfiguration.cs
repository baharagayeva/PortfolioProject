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
    internal class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Email).HasMaxLength(50);
            builder.Property(x => x.Messages).HasMaxLength(2000);
            builder.Property(x => x.Deleted).HasDefaultValue<int>(0);

            builder.HasIndex(x => new { x.Name, x.Deleted })
                   .HasDatabaseName("idx_Message_Name_Deleted");
        }
    }
}

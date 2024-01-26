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
    internal class SkillDetailConfiguration : IEntityTypeConfiguration<SkillDetail>
    {
        public void Configure(EntityTypeBuilder<SkillDetail> builder)
        {
            builder.Property(x => x.Deleted).HasDefaultValue<int>(0);

            builder.HasIndex(x => new { x.SkillID, x.Deleted})
                .HasDatabaseName("idx_SkillDetail_SkillID_Deleted");
        }
    }
}

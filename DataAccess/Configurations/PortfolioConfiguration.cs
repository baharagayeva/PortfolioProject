﻿using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    internal class PortfolioConfiguration : IEntityTypeConfiguration<Portfoli>
    {
        public void Configure(EntityTypeBuilder<Portfoli> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(50);
            builder.Property(x => x.Deleted).HasDefaultValue<int>(0);

            builder.HasIndex(x => new {x.WorkCategoryID, x.Title, x.Deleted})
                   .HasDatabaseName("idx_Portfolio_WorkCategoryID_Title_Deleted"); 
        }
    }
}

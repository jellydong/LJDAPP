using Ly.Admin.Model;
using Ly.Admin.Util.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ly.Admin.Data.EF.Database.EntityConfigurations
{
    public class SysAuthConfiguration : IEntityTypeConfiguration<SysAuth>
    {
        public void Configure(EntityTypeBuilder<SysAuth> builder)
        {
            builder.Property(a => a.Platform).HasDefaultValue(PlatformEnum.UnKnown);
            builder.Property(a => a.DeleteFlag).HasDefaultValue(StatusEnum.Yes);
            builder.Property(a => a.CreatedTime).ValueGeneratedOnAdd();
            builder.Property(a => a.UpdatedTime).ValueGeneratedOnUpdate();
        }
    }
}

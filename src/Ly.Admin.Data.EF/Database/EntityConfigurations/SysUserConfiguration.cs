using Ly.Admin.Util.Enum;
using Ly.Admin.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ly.Admin.Data.EF.Database.EntityConfigurations
{
    public class SysUserConfiguration : IEntityTypeConfiguration<SysUser>
    {
        public void Configure(EntityTypeBuilder<SysUser> builder)
        {
            builder.Property(s => s.Gender).HasDefaultValue(Gender.Unknown);
            builder.Property(s => s.Status).HasDefaultValue(StatusEnum.Yes);

            builder.Property(e => e.DeleteFlag).HasDefaultValue(StatusEnum.Yes);
            builder.Property(e => e.CreatedTime).ValueGeneratedOnAdd();
            builder.Property(e => e.UpdatedTime).ValueGeneratedOnUpdate();
        }
    }
}
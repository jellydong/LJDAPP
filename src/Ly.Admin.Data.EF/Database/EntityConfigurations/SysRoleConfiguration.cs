using Ly.Admin.Util.Enum;
using Ly.Admin.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ly.Admin.Data.EF.Database.EntityConfigurations
{
    public class SysRoleConfiguration : IEntityTypeConfiguration<SysRole>
    {
        public void Configure(EntityTypeBuilder<SysRole> builder)
        {
            builder.Property(s => s.Status).HasDefaultValue(StatusEnum.Yes);

            builder.Property(e => e.DeleteFlag).HasDefaultValue(StatusEnum.Yes);
            builder.Property(e => e.CreatedTime).ValueGeneratedOnAdd();
            builder.Property(e => e.UpdatedTime).ValueGeneratedOnUpdate();
        }
    }
}
using Ly.Admin.Util.Enum;
using Ly.Admin.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ly.Admin.Data.EF.Database.EntityConfigurations
{
    public class SysMenuConfiguration : IEntityTypeConfiguration<SysMenu>
    {
        public void Configure(EntityTypeBuilder<SysMenu> builder)
        {
            builder.Property(s => s.IsDisplay).HasDefaultValue(IsEnum.Yes);
            builder.Property(s => s.Status).HasDefaultValue(StatusEnum.Yes);

            builder.Property(e => e.DeleteFlag).HasDefaultValue(StatusEnum.Yes);
            builder.Property(e => e.CreatedTime).ValueGeneratedOnAdd();
            builder.Property(e => e.UpdatedTime).ValueGeneratedOnUpdate();
        }
    }
}
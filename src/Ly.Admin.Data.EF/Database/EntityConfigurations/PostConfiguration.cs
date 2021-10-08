using Ly.Admin.Util.Enum;
using Ly.Admin.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ly.Admin.Data.EF.Database.EntityConfigurations
{
    /// <summary>
    /// 实体属性
    /// 参考 https://docs.microsoft.com/zh-cn/ef/core/modeling/entity-properties
    /// 可以使用 数据批注 或者 Fluent API
    /// </summary>
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(x => x.Author).HasMaxLength(50).HasColumnType("varchar(50)").HasColumnName("author").HasComment("作者").HasDefaultValue((int)IsEnum.Yes);

            builder.Property(e => e.DeleteFlag).HasDefaultValue(StatusEnum.Yes);
            builder.Property(e => e.CreatedTime).ValueGeneratedOnAdd();
            builder.Property(e => e.UpdatedTime).ValueGeneratedOnUpdate();
        }
    }
}
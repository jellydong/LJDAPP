using Ly.Admin.Data.EF.Database.EntityConfigurations;
using Ly.Admin.Model;
using Microsoft.EntityFrameworkCore;

namespace Ly.Admin.Data.EF.Database
{
    // ReSharper disable once InconsistentNaming
    public class LyAdminDbContext : DbContext
    {
        /// <summary>
        /// 构造函数 调用父类构造函数
        /// </summary>
        /// <param name="options"></param>
        public LyAdminDbContext(DbContextOptions<LyAdminDbContext> options) : base(options)
        {

        } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region 实体属性 
            // 参考 https://docs.microsoft.com/zh-cn/ef/core/modeling/entity-properties
            // 可以使用 数据批注 或者 Fluent API
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new SysMenuConfiguration());
            modelBuilder.ApplyConfiguration(new SysRoleConfiguration());
            modelBuilder.ApplyConfiguration(new SysUserConfiguration());
            modelBuilder.ApplyConfiguration(new SysAuthConfiguration());
            #endregion
            base.OnModelCreating(modelBuilder);
            
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<SysMenu> SysMenu { get; set; }
        public DbSet<SysRole> SysRole { get; set; }
        public DbSet<SysUser> SysUser { get; set; }
        public DbSet<SysRRoleMenu> SysRRoleMenu { get; set; }
        public DbSet<SysRUserMenu> SysRUserMenu { get; set; }
        public DbSet<SysRUserRole> SysRUserRole { get; set; }
        public DbSet<SysAuth> SysAuth { get; set; }
        
    }
}
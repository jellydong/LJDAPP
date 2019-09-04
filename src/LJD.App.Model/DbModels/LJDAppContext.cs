using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LJD.App.Model.DbModels
{
    public partial class LJDAPPContext : DbContext
    {
        public LJDAPPContext()
        {
        }

        public LJDAPPContext(DbContextOptions<LJDAPPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Base> Base { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<R_RolePermission> R_RolePermission { get; set; }
        public virtual DbSet<R_UserPermissions> R_UserPermissions { get; set; }
        public virtual DbSet<R_sysUserInfo_sysRole> R_sysUserInfo_sysRole { get; set; }
        public virtual DbSet<SysFunction> SysFunction { get; set; }
        public virtual DbSet<SysMenus> SysMenus { get; set; }
        public virtual DbSet<SysOrganizationUnit> SysOrganizationUnit { get; set; }
        public virtual DbSet<SysRole> SysRole { get; set; }
        public virtual DbSet<SysUserInfo> SysUserInfo { get; set; }
        public virtual DbSet<WfInstanceType> WfInstanceType { get; set; }
         

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Base>(entity =>
            {
                entity.HasKey(e => e.ObjectID)
                    .HasName("PK_BASE");

                entity.Property(e => e.ObjectID)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(lower(newid()))");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedTime).HasColumnType("datetime");

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.ObjectId);

                entity.Property(e => e.ObjectId)
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Content).HasMaxLength(10);

                entity.Property(e => e.Title).HasMaxLength(10);
            });

            modelBuilder.Entity<R_RolePermission>(entity =>
            {
                entity.HasKey(e => e.ObjectID)
                    .HasName("PK_R_ROLEPERMISSION");

                entity.Property(e => e.ObjectID)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(lower(newid()))");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.FunctionID).HasMaxLength(50);

                entity.Property(e => e.MenuID).HasMaxLength(50);

                entity.Property(e => e.RoleID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Function)
                    .WithMany(p => p.R_RolePermission)
                    .HasForeignKey(d => d.FunctionID)
                    .HasConstraintName("FK_R_ROLEPE_FK_SYSPER_SYSFUNCT");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.R_RolePermission)
                    .HasForeignKey(d => d.MenuID)
                    .HasConstraintName("FK_R_ROLEPE_FK_SYSPER_SYSMENUS");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.R_RolePermission)
                    .HasForeignKey(d => d.RoleID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_R_ROLEPE_FK_SYSPER_SYSROLE");
            });

            modelBuilder.Entity<R_UserPermissions>(entity =>
            {
                entity.HasKey(e => e.ObjectID)
                    .HasName("PK_R_USERPERMISSIONS");

                entity.Property(e => e.ObjectID)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(lower(newid()))");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.FunctionID).HasMaxLength(50);

                entity.Property(e => e.HavePermission).HasDefaultValueSql("((0))");

                entity.Property(e => e.MenuID).HasMaxLength(50);

                entity.Property(e => e.UserID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Function)
                    .WithMany(p => p.R_UserPermissions)
                    .HasForeignKey(d => d.FunctionID)
                    .HasConstraintName("FK_R_USERPE_FK_R_USER_SYSFUNCT");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.R_UserPermissions)
                    .HasForeignKey(d => d.MenuID)
                    .HasConstraintName("FK_R_USERPE_FK_R_USER_SYSMENUS");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.R_UserPermissions)
                    .HasForeignKey(d => d.UserID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_R_USERPE_FK_R_USER_SYSUSERI");
            });

            modelBuilder.Entity<R_sysUserInfo_sysRole>(entity =>
            {
                entity.HasKey(e => e.ObjectID)
                    .HasName("PK_R_SYSUSERINFO_SYSROLE");

                entity.Property(e => e.ObjectID)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(lower(newid()))");

                entity.Property(e => e.RoleID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserInfoID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.R_sysUserInfo_sysRole)
                    .HasForeignKey(d => d.RoleID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_R_SYSUSE_FK_R_SYSU_SYSROLE");

                entity.HasOne(d => d.UserInfo)
                    .WithMany(p => p.R_sysUserInfo_sysRole)
                    .HasForeignKey(d => d.UserInfoID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_R_SYSUSE_FK_R_SYSU_SYSUSERI");
            });

            modelBuilder.Entity<SysFunction>(entity =>
            {
                entity.HasKey(e => e.ObjectID)
                    .HasName("PK_SYSFUNCTION");

                entity.Property(e => e.ObjectID)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(lower(newid()))");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.FFunction).HasMaxLength(50);

                entity.Property(e => e.FIcon).HasMaxLength(50);

                entity.Property(e => e.FName).HasMaxLength(50);

                entity.Property(e => e.FURL).HasMaxLength(200);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedTime).HasColumnType("datetime");

                entity.Property(e => e.ParentID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.SysFunction)
                    .HasForeignKey(d => d.ParentID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SYSFUNCT_FK_SYSFUN_SYSMENUS");
            });

            modelBuilder.Entity<SysMenus>(entity =>
            {
                entity.HasKey(e => e.ObjectID)
                    .HasName("PK_SYSMENUS");

                entity.Property(e => e.ObjectID)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(lower(newid()))");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.MArea).HasMaxLength(100);

                entity.Property(e => e.MController).HasMaxLength(100);

                entity.Property(e => e.MIcon).HasMaxLength(100);

                entity.Property(e => e.MName).HasMaxLength(100);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedTime).HasColumnType("datetime");

                entity.Property(e => e.ParentID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<SysOrganizationUnit>(entity =>
            {
                entity.HasKey(e => e.ObjectID)
                    .HasName("PK_SYSORGANIZATIONUNIT");

                entity.Property(e => e.ObjectID)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(lower(newid()))");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedTime).HasColumnType("datetime");

                entity.Property(e => e.OuName).HasMaxLength(50);

                entity.Property(e => e.OuParentID).HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<SysRole>(entity =>
            {
                entity.HasKey(e => e.ObjectID)
                    .HasName("PK_SYSROLE");

                entity.Property(e => e.ObjectID)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(lower(newid()))");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedTime).HasColumnType("datetime");

                entity.Property(e => e.RName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<SysUserInfo>(entity =>
            {
                entity.HasKey(e => e.ObjectID)
                    .HasName("PK_SYSUSERINFO");

                entity.Property(e => e.ObjectID)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(lower(newid()))");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedTime).HasColumnType("datetime");

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");

                entity.Property(e => e.UDepID).HasMaxLength(50);

                entity.Property(e => e.UEmail).HasMaxLength(50);

                entity.Property(e => e.UGender).HasDefaultValueSql("((2))");

                entity.Property(e => e.ULoginName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ULoginPWD)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UMobile).HasMaxLength(11);

                entity.Property(e => e.UQQ).HasMaxLength(20);

                entity.Property(e => e.URealName)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.UTelphone).HasMaxLength(20);

                entity.HasOne(d => d.UDep)
                    .WithMany(p => p.SysUserInfo)
                    .HasForeignKey(d => d.UDepID)
                    .HasConstraintName("FK_SYSUSERI_FK_SYSUSE_SYSORGAN");
            });

            modelBuilder.Entity<WfInstanceType>(entity =>
            {
                entity.HasKey(e => e.ObjectID)
                    .HasName("PK_WFINSTANCETYPE");

                entity.Property(e => e.ObjectID)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(lower(newid()))");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedTime).HasColumnType("datetime");

                entity.Property(e => e.ParentID).HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");

                entity.Property(e => e.TypeName)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });
        }
    }
}

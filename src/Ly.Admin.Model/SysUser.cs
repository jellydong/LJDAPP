using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Ly.Admin.Util.Enum;
using Microsoft.EntityFrameworkCore;

namespace Ly.Admin.Model
{
    [Table("sys_user")]
    [Comment("用户表")]
    public class SysUser : Entity
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Column("user_name", TypeName = "varchar(20)")]
        [Comment("用户名")]
        public string UserName { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [Column("real_name", TypeName = "varchar(10)")]
        [Comment("姓名")]
        public string RealName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Column("password", TypeName = "varchar(50)")]
        [Comment("密码")]
        public string Password { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [Column("gender", TypeName = "int(1)")]
        [Comment("性别")]
        public Gender Gender { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Column("status", TypeName = "int(1)")]
        [Comment("状态")]
        public StatusEnum Status { get; set; }
    }
}
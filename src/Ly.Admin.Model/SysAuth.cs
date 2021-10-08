using Ly.Admin.Util.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ly.Admin.Model
{

    [Table("sys_auth")]
    [Comment("认证信息")]
    public class SysAuth: Entity
    {

        /// <summary>
        /// 用户ID
        /// </summary>
        [Column("user_id", TypeName = "int(11)")]
        [Description("用户ID")]
        public long UserId { get; set; }

        /// <summary>
        /// 登录平台
        /// </summary>
        [Column("platform", TypeName = "int(1)")]
        [Comment("登录平台")]
        public PlatformEnum Platform { get; set; }

        /// <summary>
        /// 刷新令牌
        /// </summary>
        [Column("refresh_token", TypeName = "varchar(50)")]
        [Comment("刷新令牌")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// 刷新令牌过期时间
        /// </summary>
        [Column("refresh_token_expired_time", TypeName = "datetime")]
        [Comment("刷新令牌过期时间")]
        public DateTime RefreshTokenExpiredTime { get; set; }

        /// <summary>
        /// 最后登录时间戳
        /// </summary>
        [Column("login_time", TypeName = "datetime")]
        [Comment("最后登录时间戳")]
        public DateTime LoginTime { get; set; }

        /// <summary>
        /// 最后登录IP
        /// </summary>
        [Column("login_IP", TypeName = "varchar(50)")]
        [Comment("最后登录IP")]
        public string LoginIP { get; set; } = string.Empty;
    }
}

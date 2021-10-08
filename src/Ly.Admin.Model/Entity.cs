using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ly.Admin.Util.Enum;
using Microsoft.EntityFrameworkCore;

namespace Ly.Admin.Model
{
    /// <summary>
    /// 实体属性
    /// 参考 https://docs.microsoft.com/zh-cn/ef/core/modeling/entity-properties
    /// 可以使用 数据批注 或者 Fluent API
    /// </summary>
    public class Entity
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [Column("id",TypeName = "int(11)")]
        [Comment("主键Id")]

        public int Id { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Column("sort_id", TypeName = "int(11)")]
        [Comment("排序")]
        public int SortId { get; set; }

        /// <summary>
        /// 删除标识
        /// </summary>
        [Column("delete_flag", TypeName = "int(1)")]
        [Comment("删除标识")]
        public StatusEnum DeleteFlag { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Column("created_by", TypeName = "int(11)")]
        [Comment("创建人")]
        public int CreatedBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("created_time", TypeName = "datetime")]
        [Comment("创建时间")]
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        [Column("update_by", TypeName = "int(11)")]
        [Comment("更新人")]
        public int? UpdatedBy { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Column("update_time", TypeName = "datetime")]
        [Comment("更新时间")]
        public DateTime? UpdatedTime { get; set; }
    }
}
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ly.Admin.Model
{
    [Table("tb_post")]
    public class Post : Entity
    {
        /// <summary>
        /// 标题
        /// </summary>
        [Column("title")]
        [Comment("标题")]
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Column("body")]
        [Comment("内容")]
        public string Body { get; set; }
        /// <summary>
        /// 作者 这里使用FluentAPI 方式去控制 具体见 LY.Admin.Repositories.Database.EntityConfigurations.PostConfiguration
        /// </summary>
        public string Author { get; set; }
    }
}
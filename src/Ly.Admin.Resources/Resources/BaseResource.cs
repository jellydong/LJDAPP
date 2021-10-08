using System;

namespace Ly.Admin.Resources
{
    public class BaseResource
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>

        public DateTime LastModified { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Ly.Admin.Resources
{
    public class VerifyCodeModel
    {
        public VerifyCodeModel()
        {
            Id = string.Empty;
            Code = string.Empty;
        }
        /// <summary>
        /// ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string Code { get; set; }
    }
}

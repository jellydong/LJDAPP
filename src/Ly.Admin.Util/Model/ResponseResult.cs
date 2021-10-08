using System;
using System.Collections.Generic;
using System.Text;

namespace Ly.Admin.Util.Model
{
    public class ResponseResult
    {
        public ResponseResult()
        {
            this.Success = false;
            this.Message = "";
        }
        public ResponseResult(bool success)
            : this(success, string.Empty)
        {

        }

        public ResponseResult(bool success, string message)
        {
            this.Success = success;
            this.Message = message;
        }


        //是否成功
        public bool Success { get; set; }
        //消息
        public string Message { get; set; }
    }

    public class ResponseResult<T> : ResponseResult where T : class
    {
        public ResponseResult()
        {

        }
        public ResponseResult(bool success,  T t)
        {
            this.Success = success;
            this.Message = "SUCCESS";
            this.Data = t;
        }
        public ResponseResult(bool success, string message, T t)
        {
            this.Success = success;
            this.Message = message;
            this.Data = t;
        }
        public T Data { get; set; }
    }
}

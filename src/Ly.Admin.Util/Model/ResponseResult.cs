using Ly.Admin.Util.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ly.Admin.Util.Model
{
    public class ResponseResult
    {
        public ResponseResult()
        {
            this.Code = ResultEnum.ERROR;
            this.Message = "";
        }
        public ResponseResult(ResultEnum code)
            : this(code, string.Empty)
        {

        }

        public ResponseResult(ResultEnum code, string message)
        {
            this.Code = code;
            this.Message = message;
        }
        public ResponseResult(bool success, string message)
        {
            this.Code = success ? ResultEnum.SUCCESS : ResultEnum.ERROR;
            this.Message = message;
        }


        //消息码 
        [JsonProperty("code")]
        public ResultEnum Code { get; set; }
        //消息
        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class ResponseResult<T> : ResponseResult where T : class, new()
    {
        public ResponseResult()
        {
            this.Result = new T();
        }
        public ResponseResult(ResultEnum code, T t)
        {
            this.Code = code;
            this.Message = "SUCCESS";
            this.Result = t;
        } 
        public ResponseResult(bool success,  T t)
        {
            this.Code = success ? ResultEnum.SUCCESS : ResultEnum.ERROR;
            this.Message = "SUCCESS";
            this.Result = t;
        }
        public ResponseResult(ResultEnum code, string message, T t)
        {
            this.Code = code;
            this.Message = message;
            this.Result = t;
        }
        [JsonProperty("result")]
        public T Result { get; set; }
    }
}

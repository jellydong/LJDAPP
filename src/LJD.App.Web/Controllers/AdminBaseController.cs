using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LJD.App.Web.Controllers
{
    public class BaseController : Controller
    {


        /// <summary>
        /// 构造成功的Table数据
        /// </summary>
        /// <param name="count">总条数</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        protected object BuildSuccessTableResult(int count, object data)
        {
            var result = new
            {
                code = 0,
                msg = "获取数据成功",
                count = count,
                data = data
            };
            var aaa = JsonConvert.SerializeObject(result);
            return result;
        }
        /// <summary>
        /// 构造失败的Table数据
        /// </summary>
        /// <param name="errMsg">错误消息</param>
        /// <returns></returns>
        protected object BuildErrorTableResult(string errMsg)
        {
            var result = new
            {
                code = 1,
                msg = errMsg
            };
            return result;
        }
    }
}
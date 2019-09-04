/// <summary>
/// ResponseResult 的摘要说明
/// </summary>
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
        : this(success, message, (object)null)
    {
    }
     

    public ResponseResult
        (bool success, string message, object data)
    {
        this.Success = success;
        this.Message = message;
        this.Data = data; 
    }
    //是否成功
    public bool Success { get; set; }
    //消息
    public string Message { get; set; }
    //数据
    public object Data { get; set; } 

}
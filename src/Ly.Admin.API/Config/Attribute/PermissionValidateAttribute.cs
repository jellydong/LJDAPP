
namespace Ly.Admin.API.Config.Attribute
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class PermissionValidateAttribute : System.Attribute
    {
        private string Default = null;

        public string AuthorizeCode { get { return Default; } }
        public PermissionValidateAttribute()
        {
        }

        public PermissionValidateAttribute(string authorizeCode)
        {
            Default = authorizeCode;
        }
    }
}

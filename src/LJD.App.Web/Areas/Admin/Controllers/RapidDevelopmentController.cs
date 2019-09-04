using System.Collections.Generic;
using LJD.App.Service.IService;
using LJD.App.Util;
using LJD.App.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace LJD.App.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RapidDevelopmentController : BaseController
    {
        private readonly IRapidDevelopmentService _rapidDevelopmentService;

        public RapidDevelopmentController(IRapidDevelopmentService rapidDevelopmentService)
        {
            _rapidDevelopmentService = rapidDevelopmentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult List(string tableName, PagerInfo pagerInfo)
        {
            var list = _rapidDevelopmentService.GetDbAllTables(tableName, pagerInfo, out var count);
            return Json(BuildSuccessTableResult(count, list));
        }

        public IActionResult BuildCode(string buildType, string tableName)
        {
            var code = string.Empty;
            var fileName = string.Empty;
            if (buildType.Equals("IRepository"))
            {
                fileName = $"I{tableName}Repository.cs";
                code = BuildIRepositoryCode(tableName);
            }
            else if (buildType.Equals("Repository"))
            {
                fileName = $"{tableName}Repository.cs";
                code = BuildRepositoryCode(tableName);
            }
            else if (buildType.Equals("IService"))
            {
                fileName = $"I{tableName}Service.cs";
                code = BuildIServiceCode(tableName);
            }
            else if (buildType.Equals("Service"))
            {
                fileName = $"{tableName}Service.cs";
                code = BuildServiceCode(tableName);
            }
            ViewData["fileName"] = fileName;
            ViewData["Code"] = code;

            return View();
        }

        private string BuildServiceCode(string tableName)
        {
            var code = $@"using LJD.App.Model.DbModels;
using LJD.App.Repository.IRepository;
using LJD.App.Service.IService;

namespace LJD.App.Service.Service
{{
    private readonly IBaseRepository<SysUser> _iBaseRepository;

    public class {tableName}Service:BaseService<{tableName}>,I{tableName}Service
    {{
        public {tableName}Service(IBaseRepository<{tableName}> iBaseRepository) : base(iBaseRepository)
        {{
            _iBaseRepository = iBaseRepository;
        }}
    }}
}}";
            return code;
        }

        private string BuildIServiceCode(string tableName)
        {
            var code = $@"using LJD.App.Model.DbModels;

namespace LJD.App.Service.IService
{{
    public interface I{tableName}Service:IBaseService<{tableName}>
    {{
        
    }}
}}";
            return code;
        }

        private string BuildIRepositoryCode(string tableName)
        {
            var code = $@"using LJD.App.Model.DbModels;

namespace LJD.App.Repository.IRepository
{{
        public interface I{tableName}Repository:IBaseRepository<{tableName}>
        {{

        }}
}}";
            return code;
        }


        private string BuildRepositoryCode(string tableName)
        {
            var code = $@"using LJD.App.Model.DbModels;
using LJD.App.Repository.IRepository;

namespace LJD.App.Repository.Repository
{{
    public class {tableName}Repository:BaseRepository<{tableName}>,I{tableName}Repository
    {{
        public {tableName}Repository(LJDAPPContext ljdAppContext) : base(ljdAppContext)
        {{
        }}
    }}
}}";
            return code;
        }


        private string BuildModelCode()
        {


            return "using System;\nusing System.Collections.Generic;\nusing Microsoft.EntityFrameworkCore.Metadata.Internal;\n\nnamespace LJD.App.Model.DbModels\n{\n    public partial class SysUser\n    { \n        public int Id { get; set; }\n        public string Code { get; set; }\n        public string Password { get; set; }\n        public int? Gender { get; set; }\n        public string ImageUrl { get; set; }\n        public DateTime? Birthday { get; set; }\n        public string Email { get; set; }\n        public string Mobile { get; set; }\n        public string WeChatAccount { get; set; }\n        public string DingTalkAccount { get; set; }\n        public string DingTalkId { get; set; }\n        public string OfficePhone { get; set; }\n        public string QQ { get; set; }\n        public string Address { get; set; }\n        public int? IsAdministrator { get; set; }\n        public string Name { get; set; }\n        public string Description { get; set; }\n        public string UnitId { get; set; }\n        public DateTime? CreatedTime { get; set; }\n        public DateTime? ModifiedTime { get; set; }\n        public int? SortKey { get; set; }\n        public int? State { get; set; }\n    }\n}\n";
        }


    }
}
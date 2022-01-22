using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Ly.Admin.Model;
using Ly.Admin.Util;
using Ly.Admin.Util.Enum;

namespace Ly.Admin.Data.EF.Database
{
    /// <summary>
    /// 数据初始化
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class LyAdminDbContextSeed
    {
        public static async Task SeedAsync(LyAdminDbContext lyAdminDbContext, ILoggerFactory loggerFactory, int retry = 0)
        {
            int retryForAvailability = retry;
            try
            {
                // todo:Only run this if using a real database

                if (!lyAdminDbContext.SysUser.Any())
                {
                    lyAdminDbContext.SysUser.AddRange(
                        new List<SysUser>
                        {
                            new SysUser
                            {
                                UserName="admin",
                                RealName="管理员",
                                Password="admin".ToMD5String(),
                                Gender=Gender.Male,
                                Status=StatusEnum.Yes,
                                SortId=1,
                                DeleteFlag=StatusEnum.Yes,
                                CreatedBy=0,
                                CreatedTime=DateTime.Now
                            }
                        }
                    );
                    await lyAdminDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                //失败重试
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var logger = loggerFactory.CreateLogger<LyAdminDbContextSeed>();
                    logger.LogError(ex.Message);
                    await SeedAsync(lyAdminDbContext, loggerFactory, retryForAvailability);
                }
            }
        }
    }
}
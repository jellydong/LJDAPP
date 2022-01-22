using Autofac.Extensions.DependencyInjection;
using Ly.Admin.Data.EF.Database;
using Serilog;

namespace Ly.Admin.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region  配置 Serilog
            #region 从配置文件获取
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("LYAdminConfig.serilog.json")
                .Build();
            #endregion

            Log.Logger = new LoggerConfiguration()
                //最小的输出级别
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
            #region 不从配置文件的话就开启下面的代码
                // 配置日志输出到控制台
                //.WriteTo.Console()
                // 配置日志输出到文件，文件输出到当前项目的 logs 目录下
                // 日记的生成周期为每天
                //.WriteTo.File(Path.Combine("logs", @"log.txt"), rollingInterval: RollingInterval.Day)
            #endregion
            #region 读取配置文件的
                .ReadFrom.Configuration(configuration)
            #endregion
                .CreateLogger();
            #endregion

            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();

                try
                {
                    //程序一开始的时候初始化数据库的默认数据
                    var myContext = services.GetRequiredService<LyAdminDbContext>();
                    LyAdminDbContextSeed.SeedAsync(myContext, loggerFactory).Wait();
                }
                catch (Exception e)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(e, "初始化数据失败");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                //改用 Autofac 来实现依赖注入
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())

                // 将 Serilog 设置为日志记录提供程序
                .UseSerilog(dispose: true)//dispose:true退出时释放日志对象
                                          //添加自定义配置文件
                .ConfigureAppConfiguration((context, configBuilder) =>
                {
                    //configBuilder.Sources.Clear();//清除之前所有的或指定文件

                    //暂时不需要清除 只是多加一个
                    configBuilder.AddJsonFile("LYAdminConfig.options.json");
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }

    }
}

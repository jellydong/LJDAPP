using Autofac;
using Autofac.Extensions.DependencyInjection;
using Ly.Admin.API.Config.Filters;
using Ly.Admin.Auth;
using Ly.Admin.Core.Autofac;
using Ly.Admin.Core.AutoMapper;
using Ly.Admin.Data.EF.Database;
using Ly.Admin.Util.Configuration;
using Ly.Admin.Util.WebApp;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;

namespace Ly.Admin.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers(options => {
                //添加配置
                //权限验证
                options.Filters.Add<PermissionValidateFilter>();
            })
            #region asp.net core 2.0 默认返回的结果格式是Json, 并使用json.net对结果默认做了camel case的转化(大概可理解为首字母小写).  这一点与老.net web api 不一样, 原来的 asp.net web api 默认不适用任何NamingStrategy, 需要手动加上camelcase的转化. 如果非得把这个规则去掉, 那么就在configureServices里面改一下:
            .AddNewtonsoftJson(options =>
            {
                //日期处理 日期类型默认格式化处理
                options.SerializerSettings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";

                //不更改元数据的key的大小写
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();

            }) 
            #endregion
            ;

            services.AddDbContext<LyAdminDbContext>(options =>
            {
                //配置：https://docs.microsoft.com/zh-cn/ef/core/logging-events-diagnostics/extensions-logging?tabs=v3
                //启用显示敏感数据
                options.EnableSensitiveDataLogging(true);
                //日志
                options.UseLoggerFactory(MyLoggerFactory);
                //详细查询异常
                options.EnableDetailedErrors();
                var connectionString = this.Configuration["ConnectionStrings:MySqlConn"];
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            #region AutoMapper
            services.AddAutoMapper(MapperRegister.MapType());
            #endregion

            #region 依赖注入
            //AddTransient：瞬时模式每次请求，都获取一个新的实例。即使同一个请求获取多次也会是不同的实例

            //AddScoped：每次请求，都获取一个新的实例。同一个请求获取多次会得到相同的实例

            //AddSingleton单例模式：每次都获取同一个实例
            #region 两种都可以
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();
            #endregion
            #endregion
             
            services.AddJwtAuth();

            #region Swagger 
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",//版本
                    Title = "Ly.Admin.API",//标题
                    Description = "Ly.Admin.API 接口项目",//描述
                    Contact = new OpenApiContact { Name = "Jelly", Email = "", Url = new Uri("https://www.525600.xyz") },
                    License = new OpenApiLicense { Name = "License", Url = new Uri("https://www.525600.xyz") }
                });
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//获取应用程序所在目录（绝对，不受工作目录影响，建议采用此方法获取路径）
                                                                                        //var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "Ly.Admin.API.xml");//这个是右键属性生成输出中配置的xml文件名
                                                                         //c.IncludeXmlComments(xmlPath);//默认的第二个参数是false,对方法的注释
                c.IncludeXmlComments(xmlPath, true); //这个是controller的注释
            });
            #endregion


            #region 配置直接获取 LY.Admin.Util\Configuration\LYAdminOptions.cs
            var lyAdminConfigOptions = File.ReadAllText("LYAdminConfig.options.json");
            var lyAdminOptionsRoot = JsonConvert.DeserializeObject<LyAdminOptionsRoot>(lyAdminConfigOptions);
            if (lyAdminOptionsRoot == null)
            {
                throw new NullReferenceException("LYAdminConfig.options.json error");

            }
            GlobalSettings.LyAdminOptions = lyAdminOptionsRoot.LyAdminOptions;

            #endregion
        }


        #region Autofac 

        public ILifetimeScope AutoFacContainer { get; private set; }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new CustomAutofacModule());
        }
        #endregion

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                #region Swagger 只在开发环节中使用
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ly.Admin.API v1");
                    c.RoutePrefix = string.Empty;     //如果是为空 访问路径就为 根域名/index.html,注意localhost:5000/swagger是访问不到的
                                                      //路径配置，设置为空，表示直接在根域名（localhost:5000）访问该文件
                                                      // c.RoutePrefix = "swagger"; // 如果你想换一个路径，直接写名字即可，比如直接写c.RoutePrefix = "swagger"; 则访问路径为 根域名/swagger/index.html
                                                      //c.DisplayOperationId();
                                                      //c.DefaultModelExpandDepth(1); //模型示例部分中模型的默认扩展深度。
                                                      //c.DefaultModelsExpandDepth(1);//模型的默认扩展深度（设置为-1将完全隐藏模型）
                                                      //c.DefaultModelRendering(ModelRendering.Model); //控制首次呈现API时如何显示模型。
                                                      //c.DisplayRequestDuration(); //控制Try-It-Out请求的请求持续时间（以毫秒为单位）的显示。
                                                      //c.DocExpansion(DocExpansion.None); //控制操作和标签的默认扩展设置。
                                                      //c.EnableFilter(); //顶部栏将显示一个编辑框，过滤显示
                                                      //c.ShowExtensions();
                });
                #endregion
            }

            #region Autofac
            this.AutoFacContainer = app.ApplicationServices.GetAutofacRoot();
            //将当前的容器保存起来，用于后续使用
            AutofacHelper._autoFacContainer = app.ApplicationServices.GetAutofacRoot();
            #endregion

            app.UseRouting();

            // 1、先开启认证
            app.UseAuthentication();
            // 2、再开启授权
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

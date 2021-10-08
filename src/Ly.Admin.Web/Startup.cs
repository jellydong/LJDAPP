using Autofac;
using Autofac.Extensions.DependencyInjection;
using Ly.Admin.Auth;
using Ly.Admin.Core.AutoMapper;
using Ly.Admin.Util.Configuration;
using Ly.Admin.Util.WebApp;
using Ly.Admin.Web.Clients;
using Ly.Admin.Web.Config.Filters;
using Ly.Admin.Web.DelegatingHandlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ly.Admin.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(options =>
            {
                //添加配置
                //添加过滤器 登陆验证  全局过滤器
                options.Filters.Add<CheckLoginFilters>();
                //权限验证
                //options.Filters.Add<CheckPermissionFilters>();
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

            #region 依赖注入
            //AddTransient：瞬时模式每次请求，都获取一个新的实例。即使同一个请求获取多次也会是不同的实例

            //AddScoped：每次请求，都获取一个新的实例。同一个请求获取多次会得到相同的实例

            //AddSingleton单例模式：每次都获取同一个实例 

            //这里注入后 LY.Admin.Util\WebApp\HttpContextCore.cs 才能获取
            #region 两种都可以
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();


            #endregion
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

            services.AddSingleton<LyAdminRequestDelegatingHandler>();
            services.AddScoped<WeatherForecastServiceClient>();
            services.AddScoped<AuthServiceClient>();
            services.AddScoped<AccountServiceClient>();

            services.AddHttpClient("LyAdminApiService", client =>
            {
                client.DefaultRequestHeaders.Add("client-name", "Ly.Admin.Web");
                client.BaseAddress = new Uri("http://localhost:5000");
            }).SetHandlerLifetime(TimeSpan.FromMinutes(20))
            .AddHttpMessageHandler(provider => provider.GetService<LyAdminRequestDelegatingHandler>());

           
        }


        #region Autofac 

        public ILifetimeScope AutoFacContainer { get; private set; }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // InstancePerLifetimeScope 同一个 Lifetime 生成的对象是同一个实例
            // SingleInstance 单例模式，每次调用，都会使用同一个实例化的对象；每次都用同一个对象
            // InstancePerDependency 默认模式，每次调用，都会重新实例化对象；每次请求都创建一个新的对象
            #region 身份认证需要用到
            builder.RegisterType<LyAdminLoginHandler>().As<ILoginHandler>().SingleInstance();
            builder.RegisterType<LoginInfo>().As<ILoginInfo>().SingleInstance();
            builder.RegisterType<LyAdminJwtSecurityTokenHandler>().InstancePerLifetimeScope(); 
            #endregion
        }
        #endregion

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            #region Autofac
            this.AutoFacContainer = app.ApplicationServices.GetAutofacRoot();
            //将当前的容器保存起来，用于后续使用
            AutofacHelper._autoFacContainer = app.ApplicationServices.GetAutofacRoot();
            #endregion


            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

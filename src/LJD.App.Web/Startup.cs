using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using LJD.App.Model.DbModels;
using LJD.App.Util;
using LJD.App.Util.AutoFac; 
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace LJD.App.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            #region 这段代码开启后 Session不能使用
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //}); 
            #endregion
            services.AddDbContext<LJDAPPContext>(options =>
            {
                var connectionString = this.Configuration["ConnectionStrings:MySqlConn"];
                options.UseMySQL(connectionString);
            });
            //Session设置
            services.AddSession(options =>
            {
                //设置Session过期时间
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
            }); 


            services.AddMvc(options =>
                { 
                    //添加配置 
                    //添加过滤器 登陆验证  全局过滤器
                    options.Filters.Add<CheckLoginFilters>();
                    //权限验证
                    options.Filters.Add<CheckPermissionFilters>();
                }) 
            #region asp.net core 2.0 默认返回的结果格式是Json, 并使用json.net对结果默认做了camel case的转化(大概可理解为首字母小写).  这一点与老.net web api 不一样, 原来的 asp.net web api 默认不适用任何NamingStrategy, 需要手动加上camelcase的转化. 如果非得把这个规则去掉, 那么就在configureServices里面改一下:
            .AddJsonOptions(options =>
            {
                if (options.SerializerSettings.ContractResolver is DefaultContractResolver resolver)
                {
                    resolver.NamingStrategy = null;
                }
            })
            #endregion
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            #region MyRegion
            //AddTransient：瞬时模式每次请求，都获取一个新的实例。即使同一个请求获取多次也会是不同的实例

            //AddScoped：每次请求，都获取一个新的实例。同一个请求获取多次会得到相同的实例

            //AddSingleton单例模式：每次都获取同一个实例
            #endregion

            services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();

            //用Autofac来替换IOC容器 返回值由 void 修改为 IServiceProvider
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<DefaultModule>();
            containerBuilder.Populate(services);
            var container = containerBuilder.Build();
            //将当前的容器保存起来，用于后续使用
            AutofacHelper.Container = container;
            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //}
            app.UseDeveloperExceptionPage();


            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

            app.UseMvc(routes =>
            {
                //默认路由
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                //区域
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }

}

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.Admin.Auth
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddJwtAuth(this IServiceCollection services)
        {
            #region 本类库用到的依赖注入
            services.AddSingleton<ILoginHandler, LyAdminLoginHandler>();
            services.AddSingleton<ILoginInfo, LoginInfo>();  
            services.AddScoped<LyAdminJwtSecurityTokenHandler>();
            #endregion

            //从服务容器中获取自定义令牌验证处理器
            var lyAdminJwtSecurityTokenHandler = services.BuildServiceProvider().GetService<LyAdminJwtSecurityTokenHandler>();


            //配置认证服务
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                #region MyRegion
                //一.TokenValidationParameters的参数默认值：
                //1.ValidateAudience = true,  -----如果设置为false,则不验证Audience受众人
                //2.ValidateIssuer = true ,   -----如果设置为false,则不验证Issuer发布人，但建议不建议这样设置
                //3.ValidateIssuerSigningKey = false,
                //4.ValidateLifetime = true,  -----是否验证Token有效期，使用当前时间与Token的Claims中的NotBefore和Expires对比
                //5.RequireExpirationTime = true, -----是否要求Token的Claims中必须包含Expires
                //6.ClockSkew = TimeSpan.FromSeconds(300), -----允许服务器时间偏移量300秒，即我们配置的过期时间加上这个允许偏移的时间值，才是真正过期的时间(过期时间 + 偏移值)你也可以设置为0，ClockSkew = TimeSpan.Zero


                //在JwtBearerOptions的配置中，通常IssuerSigningKey(签名秘钥), ValidIssuer(Token颁发机构), ValidAudience(颁发给谁) 三个参数是必须的，后两者用于与TokenClaims中的Issuer和Audience进行对比，不一致则验证失败。

                #endregion
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    //是否验证发行人
                    ValidateIssuer = true,
                    //ValidIssuer = Issurer,//发行人
                    //是否验证受众人
                    ValidateAudience = true,
                    //ValidAudience = Audience,//受众人
                    //是否验证密钥
                    ValidateIssuerSigningKey = true,
                    //IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretCredentials)),

                    ValidateLifetime = true, //验证生命周期，MVC版Token保存Cookies时不验证
                    RequireExpirationTime = true, //过期时间
                    ClockSkew = TimeSpan.FromSeconds(60)
                };
                //先清除在添加自定义令牌验证器
                options.SecurityTokenValidators.Clear();
                options.SecurityTokenValidators.Add(lyAdminJwtSecurityTokenHandler);



            });

            return services;
        }
    }
}

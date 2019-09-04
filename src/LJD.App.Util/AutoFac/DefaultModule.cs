using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace LJD.App.Util.AutoFac
{
    public class DefaultModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // InstancePerLifetimeScope 同一个 Lifetime 生成的对象是同一个实例
            // SingleInstance 单例模式，每次调用，都会使用同一个实例化的对象；每次都用同一个对象
            // InstancePerDependency 默认模式，每次调用，都会重新实例化对象；每次请求都创建一个新的对象
             
            //告诉autofac框架注册数据仓储层所在程序集中的所有类的对象实例
            Assembly respAss = Assembly.Load("LJD.App.Repository");
            //创建respAss中的所有类的instance以此类的实现接口存储
            //builder.RegisterTypes(respAss.GetTypes()).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(respAss)
                .Where(t => t.Name.EndsWith("Repository") && !t.Name.StartsWith("I"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            //告诉autofac框架注册业务逻辑层所在程序集中的所有类的对象实例
            Assembly serpAss = Assembly.Load("LJD.App.Service");
            //创建serAss中的所有类的instance以此类的实现接口存储
            //builder.RegisterTypes(serpAss.GetTypes()).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(serpAss)
                .Where(t => (t.Name.EndsWith("Service") && !t.Name.StartsWith("I")) || t.Name.Equals("UnitOfWork"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

        }
    }
}
using Autofac;
namespace Ly.Admin.Util.WebApp
{
    public class AutofacHelper
    {
        public static ILifetimeScope _autoFacContainer;

        public static T GetService<T>()
        {
            return (T)_autoFacContainer?.Resolve(typeof(T));
        }
    }
}
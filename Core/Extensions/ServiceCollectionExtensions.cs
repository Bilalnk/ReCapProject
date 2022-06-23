#region info

// Bilal Karataş20220623

#endregion

using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        //IServiceCollection' ı genişletip metod tanımladık.
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection,
            ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }

            return ServiceTool.Create(serviceCollection);
        }
    }
}
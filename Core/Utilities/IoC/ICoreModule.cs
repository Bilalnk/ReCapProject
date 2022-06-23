#region info

// Bilal Karataş20220623

#endregion

using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}
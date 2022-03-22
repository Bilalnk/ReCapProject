#region info

// Bilal Karataş20220322

#endregion

using System;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;

namespace Core.Utilites.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var methodAttributes =
                type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);

            classAttributes.AddRange(methodAttributes);

            return classAttributes.OrderBy(attribute => attribute.Priority).ToArray();
        }
    }
}
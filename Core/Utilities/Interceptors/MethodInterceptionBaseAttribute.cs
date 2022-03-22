#region info

// Bilal Karataş20220322

#endregion

using System;
using Castle.DynamicProxy;

namespace Core.Utilites.Interceptors
{
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {
        }
    }
}
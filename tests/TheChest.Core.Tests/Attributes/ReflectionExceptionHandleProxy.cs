using System.Reflection;

namespace TheChest.Core.Tests.Attributes
{
    internal class ReflectionExceptionHandleProxy<T> : DispatchProxy
    {
        private T? target;

        public ReflectionExceptionHandleProxy() { }

        public ReflectionExceptionHandleProxy(T target)
        {
            this.target = Create(target);
        }

        public static T Create(T target)
        {
            object proxy = Create<T, ReflectionExceptionHandleProxy<T>>() 
                ?? throw new InvalidOperationException("Failed to create proxy instance.");
            
            ((ReflectionExceptionHandleProxy<T>)proxy).target = target;

            return (T)proxy;
        }

        protected override object? Invoke(MethodInfo? targetMethod, object?[]? args)
        {
            if (targetMethod == null)
                throw new ArgumentNullException(nameof(targetMethod));
            try
            {
                return targetMethod.Invoke(target, args);
            }
            catch (TargetInvocationException ex) when (ex.InnerException != null)
            {
                var inner = ex.InnerException;
                var attribute = targetMethod.GetCustomAttribute<ReflectionExceptionHandleAttribute>();
                
                if (inner.GetType() != typeof(TargetInvocationException))
                    throw inner;

                if (attribute != null && inner.InnerException != null)
                    throw inner.InnerException;

                throw inner;
            }
        }
    }
}

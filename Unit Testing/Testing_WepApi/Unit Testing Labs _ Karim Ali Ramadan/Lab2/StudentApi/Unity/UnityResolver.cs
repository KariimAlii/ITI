using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Unity;

namespace StudentApi.Unity
{
    public class UnityResolver : IDependencyResolver
    {
        private readonly IUnityContainer unityContainer;

        public UnityResolver()
        {
        }

        public UnityResolver(IUnityContainer _unityContainer)
        {
            unityContainer = _unityContainer;
        }

        public IDependencyScope BeginScope()
        {
            var child =unityContainer.CreateChildContainer();
            return new UnityResolver(child);
        }

        public void Dispose()
        {
            unityContainer.Dispose();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return unityContainer.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return unityContainer.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Autofac;
using Autofac.Integration.Mvc;

namespace Sandbox.Web
{
    public class AutofacContainer : IDependencyResolver
    {
        private readonly AutofacDependencyResolver _container;

        public AutofacContainer(AutofacDependencyResolver container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            _container = container;
        }

        /// <summary>
        /// Retrieves a service from the scope.
        /// </summary>
        public object GetService(Type serviceType)
        {
            return _container.ApplicationContainer.IsRegistered(serviceType) ? _container.GetService(serviceType) : null;
        }

        /// <summary>
        /// Retrieves a collection of services from the scope.
        /// </summary>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.ApplicationContainer.IsRegistered(serviceType) ? _container.GetServices(serviceType) : new List<object>();
        }

        /// <summary>
        /// Starts a resolution scope.
        /// </summary>
        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {
            _container.ApplicationContainer.Dispose();
        }
    }
}
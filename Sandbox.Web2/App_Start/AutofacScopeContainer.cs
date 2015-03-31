using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Autofac;
using Autofac.Integration.Mvc;

namespace Sandbox.Web2
{
    /// <summary>
    /// Autofac Scope Container
    /// </summary>
    public class AutofacScopeContainer : IDependencyScope
    {
        /// <summary>
        /// Private _container field
        /// </summary>
        private readonly AutofacDependencyResolver _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="AutofacScopeContainer"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <exception cref="System.ArgumentNullException">container</exception>
        protected AutofacScopeContainer(AutofacDependencyResolver container)
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
        /// <param name="serviceType">The service to be retrieved.</param>
        /// <returns>
        /// The retrieved service.
        /// </returns>
        public object GetService(Type serviceType)
        {
            return _container.ApplicationContainer.IsRegistered(serviceType) ? _container.GetService(serviceType) : null;
        }

        /// <summary>
        /// Retrieves a collection of services from the scope.
        /// </summary>
        /// <param name="serviceType">The collection of services to be retrieved.</param>
        /// <returns>
        /// The retrieved collection of services.
        /// </returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.ApplicationContainer.IsRegistered(serviceType) ? _container.GetServices(serviceType) : new List<object>();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _container.ApplicationContainer.Dispose();
        }

    }

    public class AutoFacContainer : AutofacScopeContainer, IDependencyResolver
    {
        public AutoFacContainer(AutofacDependencyResolver container)
            : base(container)
        {
        }

        /// <summary>
        /// Starts a resolution scope.
        /// </summary>
        /// <returns>
        /// The dependency scope.
        /// </returns>
        public IDependencyScope BeginScope()
        {
            return this;
        }
    }
}
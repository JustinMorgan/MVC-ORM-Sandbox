using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Sandbox.Domain;

namespace Sandbox.Web2
{
    public class AutofacConfig
    {
        public static void RegisterAutoFac(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            var assembly = Assembly.GetExecutingAssembly();

            RegisterTypes(builder);
            RegisterMvc(builder, assembly);

            var container = builder.Build();

            SetMvcDependencyResolver(container);

            //todo: is this redundant?
            config.DependencyResolver = new AutoFacContainer(new AutofacDependencyResolver(container));
        }

        private static void RegisterTypes(ContainerBuilder builder)
        {
            //builder.Register(x => x.Resolve<ISessionFactory>().OpenSession()).InstancePerRequest();
            builder.RegisterType<FakePersonRepository>().As<IPersonRepository>();
        }

        private static void RegisterMvc(ContainerBuilder builder, Assembly assembly)
        {
            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterFilterProvider();
            builder.RegisterControllers(assembly);
        }

        private static void SetMvcDependencyResolver(IContainer container)
        {
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
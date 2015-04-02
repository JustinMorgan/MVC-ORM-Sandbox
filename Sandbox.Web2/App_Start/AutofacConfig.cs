using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using NHibernate;
using Sandbox.Persistence.Common;
using Sandbox.Persistence.NHibernate;
using Sandbox.Persistence.NHibernate.Startup;
using NHConfiguration = NHibernate.Cfg.Configuration;

namespace Sandbox.Web2
{
    public class AutofacConfig
    {
        public static void RegisterAutoFac(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            var assembly = Assembly.GetExecutingAssembly();

            RegisterPersistence(builder);
            RegisterMvc(builder, assembly);

            var container = builder.Build();

            SetMvcDependencyResolver(container);

            //todo: is this redundant?
            config.DependencyResolver = new AutoFacContainer(new AutofacDependencyResolver(container));
        }

        private static void RegisterPersistence(ContainerBuilder builder)
        {
            builder.RegisterInstance(NHBootstrapper.Configure()).SingleInstance();
            builder.Register(x => x.Resolve<NHConfiguration>().BuildSessionFactory()).SingleInstance();
            builder.Register(x => x.Resolve<ISessionFactory>().OpenSession()).InstancePerDependency();
            builder.RegisterType<NHUnitOfWork>().As<IUnitOfWork>().InstancePerDependency();
            builder.RegisterType<NHPersonRepository>().As<IPersonRepository>();
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
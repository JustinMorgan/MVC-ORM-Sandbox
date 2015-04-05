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

namespace Sandbox.Web
{
    public class AutofacConfig
    {
        public void Configure(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            RegisterPersistence(builder);

            var assembly = Assembly.GetExecutingAssembly();
            RegisterMvc(builder, assembly);

            var container = builder.Build();
            SetMvcDependencyResolver(container, config);
        }

        protected virtual void RegisterPersistence(ContainerBuilder builder)
        {
            builder.RegisterInstance(NHBootstrapper.Configure()).SingleInstance();
            builder.Register(x => x.Resolve<NHConfiguration>().BuildSessionFactory()).SingleInstance();
            builder.Register(x => x.Resolve<ISessionFactory>().OpenSession()).InstancePerDependency();
            builder.RegisterType<NHUnitOfWork>().As<IUnitOfWork>().InstancePerDependency();
            builder.RegisterType<NHPersonRepository>().As<IPersonRepository>().SingleInstance();
        }

        protected virtual void RegisterMvc(ContainerBuilder builder, Assembly assembly)
        {
            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterFilterProvider();
            builder.RegisterControllers(assembly);
        }

        protected virtual void SetMvcDependencyResolver(IContainer container, HttpConfiguration config)
        {
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            config.DependencyResolver = new AutofacContainer(new AutofacDependencyResolver(container));
        }
    }
}
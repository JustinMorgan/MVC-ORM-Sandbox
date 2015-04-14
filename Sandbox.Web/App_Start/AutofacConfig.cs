using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using NHibernate;
using NHibernate.Cfg;
using Sandbox.Persistence;
using Sandbox.Persistence.Common;
using Sandbox.Persistence.NHibernate;
using Sandbox.Persistence.NHibernate.Startup;
using Sandbox.Persistence.Startup;
using Sandbox.Web.Utils;
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
            builder.RegisterType<NHDatabaseConfig>().As<IDatabaseConfigurer>().SingleInstance();
            builder.RegisterType<NHMappingConfig>().As<IMappingConfigurer>().SingleInstance();
            builder.RegisterType<NHSchemaConfig>().As<ISchemaConfigurer>().SingleInstance();
            builder.RegisterType<NHBootstrapper>().SingleInstance();

            builder.Register<NHConfiguration>(x => x.Resolve<NHBootstrapper>().Configure()).SingleInstance();

            builder.Register(x => x.Resolve<NHConfiguration>().BuildSessionFactory()).SingleInstance();
            //builder.Register(x => x.Resolve<ISessionFactory>().GetCurrentSession()).InstancePerHttpRequest();
            builder.RegisterType<NHUnitOfWork>().As<IUnitOfWork>().InstancePerHttpRequest();
            builder.RegisterType<NHPersonRepository>().As<IPersonRepository>().InstancePerHttpRequest();
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
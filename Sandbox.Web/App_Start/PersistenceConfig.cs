using System.Configuration;
using System.Reflection;
using Autofac;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Data;
using NHibernate;
using NHibernate.Bytecode;
using NHibernate.Cfg;
using NHibernate.Dialect;
using Sandbox.Domain;
using Sandbox.Domain.Models;
using NHConfiguration = NHibernate.Cfg.Configuration;

namespace Sandbox.Web
{
    public static class PersistenceConfig
    {
        /*
        public static void RegisterPersistenceTypes(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof (Repository<>)).As(typeof (IRepository<>)).SingleInstance();
            builder.RegisterType<PersonRepository>().As<IPersonRepository>().SingleInstance();
            builder.Register(c => CreateSessionFactory()).SingleInstance();
            builder.RegisterType<NHUnitOfWork>().As<INHUnitOfWork>().InstancePerDependency();
        }*/

        public static ISessionFactory CreateSessionFactory()
        {
            var connString = ConfigurationManager.ConnectionStrings["Sandbox"].ConnectionString;
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connString))
                .Mappings(m => 
                    m.AutoMappings.Add(
                        AutoMap.Assembly(typeof(IRepository<>).Assembly)
                               .Where(t => 
                                   t.IsAssignableFrom(typeof(Entity)))))
                .BuildSessionFactory();
        }




        public static NHConfiguration Configure()
        {
            var configuration = new NHConfiguration();
            configuration.SessionFactory()
                .Proxy.Through<DefaultProxyFactoryFactory>()
                .Integrate.Using<MsSql2008Dialect>()
                .Connected.ByAppConfing("Sandbox");

            return Fluently.Configure(configuration)
                .Mappings(map =>
                    map.AutoMappings.Add(new ModelGenerator().Generate()))
                .BuildConfiguration();
        }

        public static ISessionFactory GetSessionFactory()
        {
            var configuration = Configure();
            return configuration.BuildSessionFactory();
        }

        private class ModelGenerator
        {
            public AutoPersistenceModel Generate()
            {
                AutoPersistenceModel automap = new AutoPersistenceModel();

                automap.Conventions.AddFromAssemblyOf<ModelGenerator>();
                automap.UseOverridesFromAssemblyOf<ModelGenerator>();
                automap.AddEntityAssembly(Assembly.GetAssembly(typeof (Person)))
                    .Where(objectType => objectType.IsSubclassOf(typeof (Entity)));

                return automap;
            }
        }
    }
}
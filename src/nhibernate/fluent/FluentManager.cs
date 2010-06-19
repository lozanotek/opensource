namespace fluent
{
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;
    using NHibernate.ByteCode.Castle;
    using NHibernate.Cache;
    using NHibernate.Cfg;
    using NHibernate.Linq;
    using System.Linq;

    public class FluentManager
    {
        private static ISessionFactory factory;
        private static Configuration config;

        public static ISession GetSession()
        {
            if (factory == null)
            {
                var cfg = GetConfig();
                factory = cfg.BuildSessionFactory();
            }

            return factory.OpenSession();
        }

        public static IQueryable<TEntity> GetQuery<TEntity>()
        {
            var session = GetSession();
            return session.Linq<TEntity>();
        }

        public static Configuration GetConfig()
        {
            if (config == null)
            {
                var sqlConfig = MsSqlConfiguration.MsSql2008
                        .ConnectionString(c => c.FromConnectionStringWithKey("nhDemo"))
                        .ProxyFactoryFactory(typeof(ProxyFactoryFactory));

                config = Fluently.Configure()
                    .Database(sqlConfig)
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<FluentManager>())
                    .BuildConfiguration();
            }

            return config;
        }
    }
}

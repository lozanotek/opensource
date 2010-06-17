namespace fluent {
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;
    using NHibernate.ByteCode.Castle;
    using NHibernate.Cache;
    using NHibernate.Cfg;

    public class FluentManager {
        private static ISessionFactory factory;
        private static Configuration config;

        public static ISession GetSession() {
            if (factory == null) {
                var sqlConfig = MsSqlConfiguration.MsSql2008
                    .ConnectionString(c => c.FromAppSetting("nhDemo"))
                    .Cache(c => c.UseQueryCache()
                                 .ProviderClass<HashtableCacheProvider>())
                    .ShowSql()
                    .ProxyFactoryFactory(typeof(ProxyFactoryFactory));

                config = Fluently.Configure()
                    .Database(sqlConfig)
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<FluentManager>())
                    .BuildConfiguration();

                factory = config.BuildSessionFactory();
            }

            return factory.OpenSession();
        }
    }
}

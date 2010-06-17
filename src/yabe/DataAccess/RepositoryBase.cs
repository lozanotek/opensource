namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using Domain;
    using NHibernate;
    using NHibernate.Expression;

    public class RepositoryBase<TEntity> : ICRUDRepository<TEntity>
        where TEntity : EntityBase, new()
    {
        public RepositoryBase()
        {
            Initialize();
        }

        protected ISessionFactory SessionFactory { get; set; }

        protected ISession GetSession()
        {
            return SessionFactory.OpenSession();
        }

        public TEntity Create(TEntity entity)
        {
            using (ISession session = GetSession())
            {
                session.Save(entity);
                session.Flush();
            }

            return entity;
        }

        public TEntity Retrieve(Guid entityId)
        {
            TEntity entity;

            using (ISession session = GetSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(TEntity));
                criteria.Add(Expression.Eq("Id", entityId));

                entity = criteria.UniqueResult<TEntity>();
            }

            return entity;
        }

        public IList<TEntity> RetrieveAll()
        {
            IList<TEntity> itemList;

            using (ISession session = GetSession())
            {
                ICriteria targetObjects = session.CreateCriteria(typeof(TEntity));
                itemList = targetObjects.List<TEntity>();
            }

            return itemList;
        }

        public void Update(TEntity entity)
        {
            using (ISession session = GetSession())
            {
                session.Update(entity);
                session.Flush();
            }
        }

        public void Delete(TEntity entity)
        {
            using (ISession session = GetSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        private void Initialize()
        {
            // Initialize
            var config = new NHibernate.Cfg.Configuration();
            config.Configure();

            // Create session factory from configuration object
            SessionFactory = config.BuildSessionFactory();
        }
    }
}

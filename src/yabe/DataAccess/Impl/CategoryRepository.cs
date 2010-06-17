namespace DataAccess
{
    using Domain;
    using NHibernate;

    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public Category GetCategoryByName(string name)
        {
            using (ISession session = GetSession())
            {
                IQuery query = session.CreateQuery("from Category c where c.Name = :name");
                query.SetString("name", name);

                var result = query.UniqueResult<Category>();
                return result;
            }
        }
    }
}
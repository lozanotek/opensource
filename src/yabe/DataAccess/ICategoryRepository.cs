namespace DataAccess
{
    using Domain;

    public interface ICategoryRepository : ICRUDRepository<Category>
    {
        Category GetCategoryByName(string name);
    }
}
namespace DataAccess
{
    using System.Collections.Generic;
    using Domain;

    public interface IPostRepository : ICRUDRepository<Post>
    {
        IList<Post> GetPostsByYear(int year);
        IList<Post> GetPostsByMonth(int year, int month);
        IList<Post> GetPostsByDay(int year, int month, int day);

        Post GetPostByTitle(string title);
    }
}
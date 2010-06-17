namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using Domain;
    using NHibernate;

    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public IList<Post> GetPostsByYear(int year)
        {
            DateTime date = new DateTime(year, 1, 1);
            return GetPostsByDate(date);
        }

        public IList<Post> GetPostsByMonth(int year, int month)
        {
            DateTime date = new DateTime(year, month, 1);
            return GetPostsByDate(date);
        }

        public IList<Post> GetPostsByDay(int year, int month, int day)
        {
            DateTime date = new DateTime(year, month, day);
            return GetPostsByDate(date);
        }

        public Post GetPostByTitle(string title)
        {
            using (ISession session = GetSession())
            {
                IQuery query = session.CreateQuery("from Post p where p.Title = :title");
                query.SetString("title", title);

                var result = query.UniqueResult<Post>();
                return result;
            }
        }

        private IList<Post> GetPostsByDate(DateTime date)
        {
            using (ISession session = GetSession())
            {
                IQuery query = session.CreateQuery("from Post p where p.PostedDate >= :date");
                query.SetDateTime("date", date);

                var result = query.List<Post>();
                return result;
            }
        }
    }
}
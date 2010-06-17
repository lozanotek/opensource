namespace Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DataAccess;
    using Domain;
    using Instrumentation;

    public class BlogEngineService : IBlogEngineService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly ICommentRepository commentRepository;
        private readonly ILogger postLogger;
        private readonly IPostRepository postRepository;

        public BlogEngineService(IPostRepository postRepo, 
                                 ICommentRepository commentRepo,
                                 ICategoryRepository categoryRepo, 
                                 ILogger log)
        {
            postRepository = postRepo;
            commentRepository = commentRepo;
            categoryRepository = categoryRepo;
            postLogger = log;
        }

        #region IBlogEngineService Members

        public Category NewCategory(string name, string description)
        {
            var category = new Category {Name = name, Description = description, CreatedDate = DateTime.Now};
            categoryRepository.Create(category);

            postLogger.LogMessage("Created category '{0}'.", category.Name);
            return category;
        }

        public Category[] GetAllCategories()
        {
            IList<Category> categories = categoryRepository.RetrieveAll();
            return (categories != null) ? categories.ToArray() : null;
        }

        public void UpdateCategory(Category category)
        {
            if (category == null)
            {
                return;
            }
            categoryRepository.Update(category);
        }

        public void DeleteCategory(string name)
        {
            Category category = categoryRepository.GetCategoryByName(name);

            if (category != null)
            {
                categoryRepository.Delete(category);
            }
        }

        public Category GetCategory(string name)
        {
            return categoryRepository.GetCategoryByName(name);
        }

        public Post NewPost(string title, string contents, DateTime postDate, Category[] categories)
        {
            var post = new Post {Title = title, Contents = contents, PostedDate = postDate};

            if (categories != null)
            {
                foreach (Category category in categories)
                {
                    post.AddCategory(category);
                }
            }

            postRepository.Create(post);

            postLogger.LogMessage("Created post '{0}'", post.Title);

            return post;
        }

        public Post NewPost(string title, string contents, Category[] categories)
        {
            return NewPost(title, contents, DateTime.Now, categories);
        }

        public Post NewPost(string title, string contents, string[] categories)
        {
            if (categories != null)
            {
                List<Category> list = new List<Category>();

                foreach (var name in categories)
                {
                    Category category = GetCategory(name);
                    if (category != null)
                    {
                        list.Add(category);
                    }
                }

                return NewPost(title, contents, list.ToArray());
            }

            return null;
        }

        public void SavePost(Post post)
        {
            if (post != null)
            {
                postRepository.Update(post);
            }
        }

        public void RemovePost(Post post)
        {
            if (post != null)
            {
                postRepository.Delete(post);
            }
        }

        public void CommentOnPost(Post post, string commentAuthor, string commentText)
        {
            var comment = new Comment {Author = commentAuthor, Text = commentText, PostedDate = DateTime.Now};
            post.AddComment(comment);

            commentRepository.Create(comment);
            postRepository.Update(post);

            postLogger.LogMessage("Created comment from '{0}' on post '{1}'", 
                                  comment.Author, post.Title);
        }

        public Post[] GetPostsForCategory(string name)
        {
            Post[] posts = null;
            Category category = categoryRepository.GetCategoryByName(name);

            if (category != null)
            {
                posts = category.Posts.ToArray();
            }

            return posts;
        }

        public Post[] GetYearlyPosts(PostDate date)
        {
            if (date == null)
            {
                return null;
            }

            IList<Post> posts = postRepository.GetPostsByYear(date.Year);
            return posts != null ? posts.ToArray() : null;
        }

        public Post[] GetMonthlyPosts(PostDate date)
        {
            if (date == null)
            {
                return null;
            }

            IList<Post> posts = postRepository.GetPostsByMonth(date.Year, date.Month);
            return posts != null ? posts.ToArray() : null;
        }

        public Post[] GetDailyPosts(PostDate date)
        {
            if (date == null)
            {
                return null;
            }

            IList<Post> posts = postRepository.GetPostsByDay(date.Year, date.Month, date.Day);
            return posts != null ? posts.ToArray() : null;
        }

        public Post[] GetAllPosts()
        {
            IList<Post> posts = postRepository.RetrieveAll();
            return posts != null ? posts.ToArray() : null;
        }

        #endregion
    }
}
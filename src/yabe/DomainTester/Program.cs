namespace DomainTester
{
    using System;
    using DataAccess;
    using Domain;

    internal class Program
    {
        private static void Main()
        {
            string title = "Test Post";
            CreatePost(title);
            //GetPost(title);
            //DeletePost(title);

            Console.Write("Press <ENTER> to exit...");
            Console.ReadLine();
        }

        private static void DeletePost(string title)
        {
            var postRepository = new PostRepository();
            var post = postRepository.GetPostByTitle(title);

            if (post != null)
            {
                postRepository.Delete(post);
            }
        }

        private static void GetPost(string title)
        {
            var postRepository = new PostRepository();
            var post = postRepository.GetPostByTitle(title);

            if (post != null)
            {
                Console.WriteLine("Found post '{0}'", post.Title);

                if (post.Categories.Count > 0)
                {
                    Console.WriteLine("Categories");
                    Console.WriteLine("-----------");
                    foreach (var category in post.Categories)
                    {
                        Console.WriteLine("- {0}", category.Name);
                    }
                }

                if (post.Comments.Count > 0)
                {
                    Console.WriteLine("Comments");
                    Console.WriteLine("-----------");
                    foreach (var comment in post.Comments)
                    {
                        Console.WriteLine("{0} said:  {1}", comment.Author, comment.Text);
                    }
                }
            }
        }

        private static void CreatePost(string title)
        {
            var postRepository = new PostRepository();
            var categoryRepository = new CategoryRepository();
            var commentRepository = new CommentRepository();

            var post = new Post
                           {
                               Title = title,
                               PostedDate = DateTime.Now,
                               Contents = "This is just a simple test post..."
                           };

            for (int i = 0; i < 10; i++)
            {
                var category = new Category
                                   {
                                       Name = "Category " + i,
                                       CreatedDate = DateTime.Now,
                                       Description = "Just a test..."
                                   };

                post.AddCategory(category);
                categoryRepository.Create(category);
            }

            for (int i = 0; i < 20; i++)
            {
                var comment = new Comment
                                  {
                                      PostedDate = DateTime.Now,
                                      Author = "Author " + i,
                                      Text = "testing..."
                                  };

                post.AddComment(comment);
                commentRepository.Create(comment);
            }

            postRepository.Create(post);
        }
    }
}

namespace Services
{
    using System;
    using Domain;

    public interface IBlogEngineService
    {
        Post NewPost(string title, string contents, DateTime postDate, Category[] categories);
        Post NewPost(string title, string contents, Category[] categories);
        Post NewPost(string title, string contents, string[] categories);
        void SavePost(Post post);
        void RemovePost(Post post);

        Category NewCategory(string name, string description);
        Category[] GetAllCategories();
        void UpdateCategory(Category category);
        void DeleteCategory(string name);
        Category GetCategory(string name);

        void CommentOnPost(Post post, string commentAuthor, string commentText);
        
        Post[] GetPostsForCategory(string name);
        Post[] GetYearlyPosts(PostDate date);
        Post[] GetMonthlyPosts(PostDate date);
        Post[] GetDailyPosts(PostDate date);
        Post[] GetAllPosts();
    }
}

namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Iesi.Collections.Generic;

    [Serializable]
    public class Post : EntityBase
    {
        private readonly ISet<Category> categories = new HashedSet<Category>();
        private readonly ISet<Comment> comments = new HashedSet<Comment>();

        public virtual string Title { get; set; }
        public virtual string Contents { get; set; }
        public virtual DateTime PostedDate { get; set; }

        public ReadOnlyCollection<Category> Categories
        {
            get
            {
                return new ReadOnlyCollection<Category>(new List<Category>(categories));
            }

        }

        public ReadOnlyCollection<Comment> Comments
        {
            get
            {
                return new ReadOnlyCollection<Comment>(new List<Comment>(comments));
            }
        }

        public void AddCategory(Category category)
        {
            if (category == null) { return; }

            categories.Add(category);
        }

        public void AddComment(Comment comment)
        {
            if (comment == null) { return; }

            comments.Add(comment);
        }
    }
}

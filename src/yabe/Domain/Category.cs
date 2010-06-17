namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Iesi.Collections.Generic;

    [Serializable]
    public class Category : EntityBase
    {
        private readonly ISet<Post> posts = new HashedSet<Post>();

        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime CreatedDate { get; set; }

        public ReadOnlyCollection<Post> Posts
        {
            get { return new ReadOnlyCollection<Post>(new List<Post>(posts)); }
        }
    }
}
namespace Domain
{
    using System;

    [Serializable]
    public class Comment : EntityBase
    {
        public virtual string Author { get; set; }
        public virtual string Text { get; set; }
        public virtual DateTime PostedDate { get; set; }
    }
}
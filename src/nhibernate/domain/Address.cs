namespace domain
{
    using System;

    [Serializable]
    public class Address : EntityBase
    {
        public virtual string Line1 { get; set; }
        public virtual string Line2 { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string Zip { get; set; }

        public override string ToString()
        {
            return string.Format("{0}\n{1}\n{2}, {3} {4}", Line1, Line2, City, State, Zip);
        }
    }
}

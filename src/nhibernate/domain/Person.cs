namespace domain
{
    using System;

    [Serializable]
    public class Person : EntityBase
    {
        public Person()
        {
            FullName = new Name();
            Address = new Address();
        }

        public virtual Name FullName { get; set; }
        public virtual Address Address { get; set; }
    }
}
namespace microkernel
{
    using System;

    internal class Foo : IFoo
    {
        #region IFoo Members

        public void SayHello()
        {
            Console.WriteLine("Hello, World!");
        }

        #endregion
    }
}
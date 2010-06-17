namespace microkernel
{
    using System;
    using Castle.MicroKernel;

    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new DefaultKernel();
            kernel.AddComponent("foo", typeof(IFoo), typeof(Foo));

            IFoo foo = kernel[typeof(IFoo)] as IFoo;

            if (foo != null)
            {
                foo.SayHello();
            }

            IFoo foo2 = kernel["foo"] as IFoo;
            if (foo2 != null)
            {
                foo2.SayHello();
            }

            Console.Write("Press <ENTER> to exit...");
            Console.ReadLine();
        }
    }
}
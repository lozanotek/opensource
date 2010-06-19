namespace microkernel
{
    using System;
    using Castle.MicroKernel;
    using Castle.MicroKernel.Resolvers.SpecializedResolvers;

    class Program
    {
        static void Main(string[] args)
        {
            SimpleRegistration();

            Console.Write("Press <ENTER> to exit...");
            Console.ReadLine();
        }

        private static void SimpleRegistration()
        {
            IKernel kernel = new DefaultKernel();

            //kernel.Resolver.AddSubResolver(new ArrayResolver(kernel));
            //kernel.Resolver.AddSubResolver(new ListResolver(kernel));

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
        }
    }
}
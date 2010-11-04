namespace windsor
{
    using System;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Castle.Windsor.Configuration.Interpreters;

    class Program
    {
        // Models singleton over transient instance models
        static void Main(string[] args)
        {
            IWindsorContainer container =
                new WindsorContainer(new XmlInterpreter("windsor.config"));

            //IWindsorContainer container = CreateContainer();

            IBar bar = container.Resolve<IBar>();
            
            if (bar != null)
            {
                bar.DisplayTime();
            }
            container.Release(bar);
            
            // Mimic a time delay.
            System.Threading.Thread.Sleep(2000);

            IBar bar2 = container.Resolve<IBar>();
            
            if (bar2 != null)
            {
                bar2.DisplayTime();
            }

            container.Release(bar2);

            Console.Write("Press <ENTER> to exit...");
            Console.ReadLine();
        }

        public static IWindsorContainer CreateContainer() {
            // http://using.castleproject.org/display/IoC/Fluent+Registration+API
            var container = new WindsorContainer();
            container.Register(
                Component.For<IBar>().ImplementedBy<Bar>().LifeStyle.Transient);

            return container;
        }
    }
}
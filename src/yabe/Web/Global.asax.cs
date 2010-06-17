namespace Web
{
    using System;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using Castle.Core;
    using MvcContrib.Castle;
    using Utilities;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            LoggingUtility.Initialize();
            RegisterMvcTypes();

            SetupControllerBuilder();
            SetupRoutes();
        }

        private static void RegisterMvcTypes()
        {
            IoC.Register<IRouteConfigurator, RouteConfigurator>("route-configurator");

            // TODO: windsor mass component registration
            // http://www.kenegozi.com/Blog/2008/03/01/windsor-mass-component-registration.aspx
            // http://mikehadlow.blogspot.com/2008/04/problems-with-mvc-framework.html

            //add all controllers
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (!typeof(IController).IsAssignableFrom(type)) continue;

                string key = type.Name.ToLower();
                IoC.Register(key, type, LifestyleType.Transient);
            }
        }

        private static void SetupRoutes()
        {
            var configurator = IoC.Resolve<IRouteConfigurator>();
            configurator.RegisterRoutes();
        }

        private static void SetupControllerBuilder()
        {
            var controllerFactory = new WindsorControllerFactory(IoC.GetContainer());
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}
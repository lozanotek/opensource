namespace Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfigurator : IRouteConfigurator
    {
        #region IRouteConfigurator Members

        public virtual void RegisterRoutes()
        {
            RouteCollection routes = RouteTable.Routes;

            routes.MapRoute("posts", "posts/{action}/{id}",
                            new { controller = "post", action = "index", id = "" });

            routes.MapRoute("categories", "categories/{action}/{id}",
                            new { controller = "category", action = "list", id = "" });

            routes.MapRoute("standard", "{controller}/{action}/{id}",
                            new { controller = "post", action = "index", id = (string)null });

            routes.MapRoute("default_aspx", "Default.aspx", new { controller = "post", action = "index" });
        }

        #endregion
    }
}

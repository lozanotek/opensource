namespace Web.Controllers
{
    using System.Web.Mvc;
    using Services;

    public abstract class BlogController : Controller
    {
        private readonly IBlogEngineService blogEngineService;

        protected BlogController(IBlogEngineService service)
        {
            blogEngineService = service;
        }

        public IBlogEngineService Engine
        {
            get { return blogEngineService; }
        }
    }
}
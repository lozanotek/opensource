namespace Web.Controllers
{
    using System.Web.Mvc;
    using Domain;
    using Services;

    public class PostController : BlogController
    {
        public PostController(IBlogEngineService service)
            : base(service)
        {
        }

        public ActionResult Index()
        {
            Post[] posts = Engine.GetAllPosts();
            ViewData["posts"] = posts;

            return View();
        }

        public ActionResult New()
        {
            Category[] categories = Engine.GetAllCategories();
            ViewData["categories"] = categories;

            return View();
        }

        public ActionResult Create(string title, string contents, string[] categoryList)
        {
            Engine.NewPost(title, contents, categoryList);
            return RedirectToAction("Index");
        }
    }
}
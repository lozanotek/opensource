namespace Web.Controllers
{
    using System.Web.Mvc;
    using MvcContrib.Filters;
    using Services;

    public class CategoryController : BlogController
    {
        public CategoryController(IBlogEngineService service)
            : base(service)
        {
        }

        public ActionResult List()
        {
            var categories = Engine.GetAllCategories();
            ViewData["categories"] = categories;

            return View();
        }

        public ActionResult New()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(string name, string description)
        {
            Engine.NewCategory(name, description);
            return RedirectToAction("List");
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace MyBlogInitiation.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

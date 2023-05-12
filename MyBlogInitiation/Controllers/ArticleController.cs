using Microsoft.AspNetCore.Mvc;
using MyBlogInitiation.Mocks;
using MyBlogInitiation.Models;
using MyBlogInitiation.ViewModels;

namespace MyBlogInitiation.Controllers
{
    public class ArticlesController : Controller
    {
        public IActionResult Index()
        {
            //Créer uen liste d'article en DUR
            var vm = new ArticlesViewModel
            {
                Articles = ArticleMock.listArticles

            };
            return View(vm);
        }
    }
}

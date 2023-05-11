using Microsoft.AspNetCore.Mvc;
using MyBlogInitiation.Models;

namespace MyBlogInitiation.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            //Créer uen liste d'article en DUR
            var vm = new ArticlesViewModel
            {
                Articles = new List<ArticleModel>
                {
                    new ArticleModel
                    {
                        Id = 0,
                        Title = "Les objets connectés 1",
                        Content = "Exemple de contenu",
                    },
                    new ArticleModel
                    {
                        Id = 1,
                        Title = "Les objets connectés 2",
                        Content = "Exemple de contenu",
                    },
                    new ArticleModel
                    {
                        Id = 3,
                        Title = "Les objets connectés 3",
                        Content = "Exemple de contenu",
                    }
                }
            };
            return View(vm);
        }
    }
}

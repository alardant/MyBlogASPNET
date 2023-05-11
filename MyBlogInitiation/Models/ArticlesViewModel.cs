namespace MyBlogInitiation.Models
{
    //La classe que je veux donner à ma vue
    public class ArticlesViewModel
    {
        public List<ArticleModel> Articles { get; set; }
    }

    // classe identique à celle en BDD
    public class ArticleModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool Available { get; set; }

    }
}

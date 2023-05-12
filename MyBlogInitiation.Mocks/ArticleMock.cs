using MyBlogInitiation.Models;

namespace MyBlogInitiation.Mocks
{
	public static class ArticleMock
	{
		public static List<ArticleModel> listArticles = new List<ArticleModel>()
		{
			new ArticleModel
				{
					Id = 0,
					Title = "Les objets connectés 1",
					Content = "Exemple de contenu",
					Available = true,
				},
				new ArticleModel
				{
					Id = 1,
					Title = "Les objets connectés 2",
					Content = "Exemple de contenu",
					Available = true,
				},
				new ArticleModel
				{
					Id = 3,
					Title = "Les objets connectés 3",
					Content = "Exemple de contenu",
					Available = true,
				}
		};
	}
}
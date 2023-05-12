using MyBlogInitiation.Models;

namespace MyBlogInitiation.Mocks
{
	public static class ArticleMock
	{
		public static List<ArticleModel> listArticles = new List<ArticleModel>()
		{
			new ArticleModel
				{
					Title = "Les objets connectés 1",
					Content = "Exemple de contenu",
					Available = true,
				},
				new ArticleModel
				{
					Title = "Les objets connectés 2",
					Content = "Exemple de contenu",
					Available = true,
				},
				new ArticleModel
				{
					Title = "Les objets connectés 3",
					Content = "Exemple de contenu",
					Available = false,
				}
		};
	}
}
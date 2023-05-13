using Microsoft.EntityFrameworkCore;
using MyBlogInitiation.Models;
using MyBlogInitiation.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogInitiation.Repository.DAL
{
	// Cette classe va servir d'intermédiaire entre l'appli web et Entity
	//AppWeb -> Repo -> Entity -> BDD
	public class ArticlesPublicDAL
	{
		private readonly DbBlogContext _dbBlogContext;
		public ArticlesPublicDAL(DbBlogContext blogContext)
		{
			_dbBlogContext = blogContext;
		}
		//Retourne un article en fonction de son id
		public async Task<ArticleModel> GetArticle(int id)
		{
			var articleModel = await _dbBlogContext.Articles.FirstOrDefaultAsync(i => i.Id == id && i.Available);
			return articleModel;
		}
		public async Task<List<ArticleModel>> GetAllArticle()
		{
			var articlesModels = await _dbBlogContext.Articles.Where(i => i.Available).ToListAsync();
			return articlesModels;
		}
	}
}

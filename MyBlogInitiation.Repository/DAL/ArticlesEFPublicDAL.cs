using Microsoft.EntityFrameworkCore;
using MyBlogInitiation.Models;
using MyBlogInitiation.Repository.Context;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogInitiation.Repository.DAL
{
	public class ArticlesEFPublicDAL
	{
		private readonly DbBlogContext _dbBlogContext;

		public ArticlesEFPublicDAL(DbBlogContext dbBlogContext)
		{
			_dbBlogContext = dbBlogContext;
		}

		public async Task<List<ArticleModel>> GetAllArticles()
		{
			var listArticle = await _dbBlogContext.Articles.Where(i=> i.Available).ToListAsync();
			return listArticle;
		}
		public async Task<ArticleModel> GetArticle(int id)
		{
			var article = await _dbBlogContext.Articles.FirstOrDefaultAsync(i => i.Id == id);
			return article;
		}
		public void AddAsync(ArticleModel article)
		{
			_dbBlogContext.AddAsync(article);
		}

		public async Task<bool> SaveAsync()
		{
			var saved = await _dbBlogContext.SaveChangesAsync();
			return saved > 0;
		}

		public void Update(ArticleModel article)
		{
			_dbBlogContext.Update(article);

		}

		public void Delete(ArticleModel article)
		{
			_dbBlogContext.Remove(article);
		}

		public bool ArticleModelExists(int id)
		{
			return (_dbBlogContext.Articles?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}

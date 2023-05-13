using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBlogInitiation.Data;
using MyBlogInitiation.Models;
using MyBlogInitiation.Repository.Context;
using MyBlogInitiation.Repository.DAL;

namespace MyBlogInitiation.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ArticlesEFController : Controller
    {
        //créer le DAL dans le projet repo
        // paramétrer l'injection dans le program.cs (addtranscient)
        // injecter le dal dans le controlleur
        // Enlever toutes les occurences à _context en les remplacant par des appels aux repo

        private readonly ArticlesEFPublicDAL _articlesEFPublicDAL;
        public ArticlesEFController(ArticlesEFPublicDAL articlesEFPublicDAL)
        {
            _articlesEFPublicDAL = articlesEFPublicDAL;
        }

        // GET: ArticlesEF
        public async Task<IActionResult> Index()
        {
            var listArticle = await _articlesEFPublicDAL.GetAllArticles();

			if (listArticle != null)
            {
                return View(listArticle);

			} else
            {
                return Problem("Entity set 'MyBlogInitiationContext.ArticleModel'  is null.");
			}
                            
        }

        // GET: ArticlesEF/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleModel = await _articlesEFPublicDAL.GetArticle(id.Value);

            if (articleModel == null)
            {
                return NotFound();
            }

            return View(articleModel);
        }

        // GET: ArticlesEF/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArticlesEF/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Content,Available")] ArticleModel articleModel)
        {
            if (ModelState.IsValid)
            {
                _articlesEFPublicDAL.AddAsync(articleModel);
                await _articlesEFPublicDAL.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(articleModel);
        }

        // GET: ArticlesEF/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleModel = await _articlesEFPublicDAL.GetArticle(id.Value);
            if (articleModel == null)
            {
                return NotFound();
            }
            return View(articleModel);
        }

        // POST: ArticlesEF/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,Available")] ArticleModel articleModel)
        {
            if (id != articleModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _articlesEFPublicDAL.Update(articleModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_articlesEFPublicDAL.ArticleModelExists(articleModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                await _articlesEFPublicDAL.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(articleModel);
        }

        // GET: ArticlesEF/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
              if (id == null)
            {
                return NotFound();
            }

            var articleModel = await _articlesEFPublicDAL.GetArticle(id.Value);
            if (articleModel == null)
            {
                return NotFound();
            }

            return View(articleModel);
        }

        // POST: ArticlesEF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_articlesEFPublicDAL == null)
            {
                return Problem("Entity set 'MyBlogInitiationContext.ArticleModel'  is null.");
            }
            var articleModel = await _articlesEFPublicDAL.GetArticle(id);
            if (articleModel != null)
            {
                _articlesEFPublicDAL.Delete(articleModel);
            }
            await _articlesEFPublicDAL.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

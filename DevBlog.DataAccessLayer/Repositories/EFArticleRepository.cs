using DevBlog.DataAccessLayer.Entities;
using DevBlog.DataAccessLayer.EntityFramework;
using DevBlog.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DevBlog.DataAccessLayer.Repositories
{
    public class EFArticleRepository : IArticleRepository
    {
        private readonly Context context;

        public IQueryable<Article> GetFields()
        {
            return context.Articles;
        }

        public IQueryable<Article> GetArticlesByTitle(string title)
        {
            return context.Articles.Where(x => x.Title == title);
        }

        public Article GetArticleById(Guid id)
        {
            return context.Articles.FirstOrDefault(x => x.Id == id);
        }

        public void SaveArticle(Article article)
        {
            if (article.Id == default)
                context.Entry(article).State = EntityState.Added;
            else
                context.Entry(article).State = EntityState.Modified;

            context.SaveChanges();
        }

        public void DeleteArticle(Guid id)
        {
            context.Articles.Remove(new Article() { Id = id });
            context.SaveChanges();
        }
    }
}

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

        public EFArticleRepository(Context dbContext)
        {
            context = dbContext;
        }

        public IQueryable<Article> Get()
        {
            return context.Articles;
        }

        public IQueryable<Article> GetByTitle(string title)
        {
            return context.Articles.Where(x => x.Title == title);
        }

        public Article GetById(Guid id)
        {
            return context.Articles.FirstOrDefault(x => x.Id == id);
        }

        public void Create(Article article)
        {
            context.Articles.Add(article);
        }

        public void Update(Article article)
        {
            context.Articles.Update(article);
        }

        public void Delete(Guid id)
        {
            var article = context.Articles.Find(id);
            if (article != null)
                context.Articles.Remove(article);
        }
    }
}

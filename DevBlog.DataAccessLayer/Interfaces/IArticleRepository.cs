using DevBlog.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevBlog.DataAccessLayer.Interfaces
{
    public interface IArticleRepository
    {
        IQueryable<Article> Get();

        Article GetById(Guid id);

        IQueryable<Article> GetByTitle(string title);

        void Create(Article article);

        void Update(Article article);

        void Delete(Guid id);
    }
}
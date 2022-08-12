using DevBlog.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevBlog.DataAccessLayer.Interfaces
{
    public interface IArticleRepository
    {
        IQueryable<Article> GetFields();
        Article GetArticleById(Guid id);
        IQueryable<Article> GetArticlesByTitle(string title);
        void SaveArticle(Article article);
        void DeleteArticle(Guid id);
    }
}

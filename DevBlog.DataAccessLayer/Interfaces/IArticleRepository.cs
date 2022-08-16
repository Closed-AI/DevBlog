using DevBlog.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevBlog.DataAccessLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetFields();
        T GetArticleById(Guid id);
        IQueryable<T> GetArticlesByTitle(string title);
        void SaveArticle(T article);
        void DeleteArticle(Guid id);
    }
}

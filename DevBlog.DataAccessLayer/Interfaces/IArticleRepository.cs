using DevBlog.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevBlog.DataAccessLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Get();
        T GetById(Guid id);
        IQueryable<T> GetByTitle(string title);
        void Create(Article article);
        void Update(Article article);
        void Delete(Guid id);
    }
}
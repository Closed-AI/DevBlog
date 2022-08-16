using DevBlog.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevBlog.DataAccessLayer.Interfaces
{
    interface IUnitOfWork : IDisposable
    {
        IRepository<Article> Articles { get; }
        void Save();
    }
}

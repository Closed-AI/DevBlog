using System;
using System.Collections.Generic;
using System.Text;
using DevBlog.DataAccessLayer.Entities;
using DevBlog.DataAccessLayer.EntityFramework;
using DevBlog.DataAccessLayer.Interfaces;
using DevBlog.DataAccessLayer.Repositories;

namespace DevBlog.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private Context db;
        private EFArticleRepository articlesRepository;
        private EFUserRepository usersRepository;

        public UnitOfWork()
        {
            db = new Context();
        }

        public IArticleRepository Articles
        {
            get
            {
                if (articlesRepository == null)
                    articlesRepository = new EFArticleRepository(db);
                return (IArticleRepository)articlesRepository;
            }
        }

        public IUserRepository Users
        {
            get
            {
                if (usersRepository == null)
                    usersRepository = new EFUserRepository(db);
                return (IUserRepository)usersRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}

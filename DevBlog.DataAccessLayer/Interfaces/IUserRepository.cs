using DevBlog.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevBlog.DataAccessLayer.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> Get();

        User GetById(Guid id);

        void Create(User article);

        void Update(User article);

        void Delete(Guid id);
    }
}

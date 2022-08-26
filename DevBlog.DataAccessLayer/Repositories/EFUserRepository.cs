using DevBlog.DataAccessLayer.Entities;
using DevBlog.DataAccessLayer.EntityFramework;
using DevBlog.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevBlog.DataAccessLayer.Repositories
{
    public class EFUserRepository : IUserRepository
    {
        private readonly Context context;

        public EFUserRepository(Context dbContext)
        {
            context = dbContext;
        }

        public IQueryable<User> Get()
        {
            return context.Users;
        }

        public User GetById(Guid id)
        {
            return context.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Create(User user)
        {
            context.Users.Add(user);
        }

        public void Update(User user)
        {
            context.Users.Update(user);
        }

        public void Delete(Guid id)
        {
            var user = context.Users.Find(id);
            if (user != null)
                context.Users.Remove(user);
        }
    }
}

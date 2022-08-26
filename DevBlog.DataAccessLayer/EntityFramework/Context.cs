using DevBlog.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevBlog.DataAccessLayer.EntityFramework
{
    public class Context : IdentityDbContext<IdentityUser>
    {
        public Context() { }

        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Article> Articles { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Database=MyCompany; Trusted_Connection=True;");
        }
    }
}
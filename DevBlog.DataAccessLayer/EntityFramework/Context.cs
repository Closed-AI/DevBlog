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

        public Context(DbContextOptions<Context> options) : base(options)
        { }

        public DbSet<Article> Articles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //"Data Source=(local)\\SQLSERVER;  Database=MyCompany; Persist Security Info=false; User ID='sa'; Password='sa'; MultipleActiveResultSets=True; Trusted_Connection=False;"

            optionsBuilder.UseSqlServer("Data Source=(local)\\SQLSERVER; Database=MyCompany; Persist Security Info=false; User ID='sa'; Password='sa'; MultipleActiveResultSets=True; Trusted_Connection=False;");
        }
    }
}

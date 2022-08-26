using System;
using System.Collections.Generic;
using System.Text;

namespace DevBlog.DataAccessLayer.Entities
{
    public class User
    {
        public User() { }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string SecondName { get; set; }

        public string ProfileImagePath { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}

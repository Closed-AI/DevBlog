using System;

namespace DevBlog.PresentationLayer.Models
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string SecondName { get; set; }

        public string ProfileImagePath { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}
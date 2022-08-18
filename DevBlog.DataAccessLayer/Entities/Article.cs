using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DevBlog.DataAccessLayer.Entities
{
    public class Article : BaseEntity
    {
        public Article() : base() {}

        public override string Title { get; set; }

        public override string Subtitle { get; set; }

        public override string Text { get; set; }
    }
}

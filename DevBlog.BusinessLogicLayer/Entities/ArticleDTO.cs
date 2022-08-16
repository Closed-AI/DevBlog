using System;
using System.Collections.Generic;
using System.Text;

namespace DevBlog.BusinessLogicLayer.Entities
{
    public class ArticleDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Text { get; set; }
        public string TitleImagePath { get; set; }
        public DateTime AddDate { get; set; }
    }
}

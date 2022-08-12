using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DevBlog.DataAccessLayer.Entities
{
    public class Article : BaseEntity
    {
        [Required(ErrorMessage = "Введите название статьи")]
        [Display(Name = "Название статьи")]
        public override string Title { get; set; }

        [Display(Name = "Краткое описание")]
        public override string Subtitle { get; set; }

        [Display(Name = "Текст статьи")]
        public override string Text { get; set; }
    }
}

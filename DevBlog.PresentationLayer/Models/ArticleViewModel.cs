using System;
using System.ComponentModel.DataAnnotations;

namespace DevBlog.PresentationLayer.Models
{
    public class ArticleViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Введите название статьи")]
        [Display(Name = "Название статьи")]
        public string Title { get; set; }

        [Display(Name = "Краткое описание")]
        public string Subtitle { get; set; }

        [Display(Name = "Текст статьи")]
        public string Text { get; set; }

        [Display(Name = "Титульное изображение")]
        public string TitleImagePath { get; set; }

        [DataType(DataType.Time)]
        public DateTime AddDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevBlog.PresentationLayer.Models
{
    public class ArticleViewModel
    {
        [Required]
        public int Id { get; set; }

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

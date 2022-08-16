using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DevBlog.DataAccessLayer.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            AddDate = DateTime.UtcNow;
        }

        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Название (заголовок)")]
        public virtual string Title { get; set; }

        [Display(Name = "Краткое описание")]
        public virtual string Subtitle { get; set; }

        [Display(Name = "Полное описание")]
        public virtual string Text { get; set; }

        [Display(Name = "Титульное изображение")]
        public virtual string TitleImagePath { get; set; }

        [DataType(DataType.Time)]
        public DateTime AddDate { get; set; }
    }
}

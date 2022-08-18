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

        public Guid Id { get; set; }

        public virtual string Title { get; set; }

        public virtual string Subtitle { get; set; }

        public virtual string Text { get; set; }

        public virtual string TitleImagePath { get; set; }

        public DateTime AddDate { get; set; }
    }
}

using DevBlog.BusinessLogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevBlog.BusinessLogicLayer.Interfaces
{
    public interface IArticleService : IDisposable
    {
        ArticleDTO GetArticle(Guid id);

        IEnumerable<ArticleDTO> GetArticles();

        void CreateArticle(ArticleDTO articleDto);

        void UpdateArticle(ArticleDTO articleDto);

        void DeleteArticle(ArticleDTO articleDto);
    }
}

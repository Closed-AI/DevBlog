using DevBlog.BusinessLogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevBlog.BusinessLogicLayer.Interfaces
{
    interface IArticleService
    {
        void MakeArticle(ArticleDTO articleDto);
        ArticleDTO GetArticle(int? id);
        IEnumerable<ArticleDTO> GetArticles();
        void Dispose();
    }
}

using DevBlog.BusinessLogicLayer.Entities;
using DevBlog.BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using DevBlog.DataAccessLayer.Interfaces;
using DevBlog.DataAccessLayer;
using DevBlog.DataAccessLayer.Entities;
using AutoMapper;

namespace DevBlog.BusinessLogicLayer
{
    public class ArticleService : IArticleService
    {
        private IUnitOfWork database;

        public ArticleService()
        {
            database = new UnitOfWork();
        }

        public void MakeArticle(ArticleDTO articleDto)
        {
            Article article = new Article
            {
                Title =          articleDto.Title,
                Subtitle =       articleDto.Subtitle,
                Text =           articleDto.Text,
                TitleImagePath = articleDto.TitleImagePath,
                AddDate =        articleDto.AddDate,
            };
            database.Articles.Create(article);
            database.Save();
        }

        public IEnumerable<ArticleDTO> GetArticles()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Article, ArticleDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Article>, List<ArticleDTO>>(database.Articles.Get());
        }

        public ArticleDTO GetArticle(int? id)
        {
            if (id == null)
                throw new Exception("Не установлен id статьи");

            var article = database.Articles.GetById(Guid.Parse(id.Value.ToString()));

            if (article == null)
                throw new Exception("Статья не найдена");

            return new ArticleDTO
            {
                Title =          article.Title,
                Subtitle =       article.Subtitle,
                Text =           article.Text,
                TitleImagePath = article.TitleImagePath,
                AddDate =        article.AddDate,
            };
        }

        public void Dispose()
        {
            database.Dispose();
        }
    }
}

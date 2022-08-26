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

        public IEnumerable<ArticleDTO> GetArticles()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Article, ArticleDTO>()).CreateMapper();
            List<ArticleDTO> result = new List<ArticleDTO>();

            foreach (var item in database.Articles.Get())
                result.Add(mapper.Map<Article, ArticleDTO>(item));

            return result;
        }

        public ArticleDTO GetArticle(Guid id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Article, ArticleDTO>()).CreateMapper();
            var article = database.Articles.GetById((Guid)id);

            if (id == null || article == default)
                return null;

            return mapper.Map<Article, ArticleDTO>(article);
        }

        public void CreateArticle(ArticleDTO articleDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ArticleDTO, Article>()).CreateMapper();
            database.Articles.Create(mapper.Map<ArticleDTO, Article>(articleDto));
            database.Save();
        }

        public void UpdateArticle(ArticleDTO articleDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ArticleDTO, Article>()).CreateMapper();
            var article = mapper.Map<ArticleDTO, Article>(articleDto);

            database.Articles.Update(article);
            database.Save();
        }

        public void DeleteArticle(ArticleDTO articleDto)
        {
            if (articleDto == null) return;
            database.Articles.Delete(articleDto.Id);
            database.Save();
        }

        public void Dispose()
        {
            database.Dispose();
        }
    }
}

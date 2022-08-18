using AutoMapper;
using DevBlog.BusinessLogicLayer.Entities;
using DevBlog.BusinessLogicLayer.Interfaces;
using DevBlog.PresentationLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrezentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleService database;

        public HomeController(IArticleService db)
        {
            database = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ArticleDTO> articleDtos = database.GetArticles();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ArticleDTO, ArticleViewModel>()).CreateMapper();
            var articles = mapper.Map<IEnumerable<ArticleDTO>, List<ArticleViewModel>>(articleDtos);

            return View(articles);
        }
    }
}

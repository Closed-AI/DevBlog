using AutoMapper;
using DevBlog.BusinessLogicLayer;
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
        public IActionResult Index()
        {
            List<ArticleViewModel> articles = new List<ArticleViewModel>();

            using (IArticleService database = new ArticleService())
            {
                IEnumerable<ArticleDTO> articleDtos = database.GetArticles();
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ArticleDTO, ArticleViewModel>()).CreateMapper();
                articles = mapper.Map<IEnumerable<ArticleDTO>, List<ArticleViewModel>>(articleDtos);
            }

            return View(articles);
        }
    }
}

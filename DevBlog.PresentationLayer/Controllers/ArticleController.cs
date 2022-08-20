using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DevBlog.BusinessLogicLayer.Interfaces;
using DevBlog.PresentationLayer.Models;
using AutoMapper;
using DevBlog.BusinessLogicLayer.Entities;
using PrezentationLayer.Controllers;
using DevBlog.PresentationLayer.Service;
using DevBlog.BusinessLogicLayer;

namespace DevBlog.PresentationLayer
{
    public class ArticleController : Controller
    {
        private readonly IWebHostEnvironment hostingEnvironment;

        public ArticleController(IWebHostEnvironment atherHostingEnvironment)
        {
            hostingEnvironment = atherHostingEnvironment;
        }

        public IActionResult Add()
        {
            ArticleViewModel entity = new ArticleViewModel();

            return View(entity);
        }

        [HttpPost]
        public IActionResult Add(ArticleViewModel model, IFormFile titleImageFile)
        {
            if (ModelState.IsValid)
            {
                if (titleImageFile != null)
                {
                    model.TitleImagePath = titleImageFile.FileName;
                    using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/", titleImageFile.FileName), FileMode.Create))
                    {
                        titleImageFile.CopyTo(stream);
                    }
                }

                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ArticleViewModel, ArticleDTO>()).CreateMapper();

                using (IArticleService database = new ArticleService())
                {
                    database.CreateArticle(mapper.Map<ArticleViewModel, ArticleDTO>(model));
                }

                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }

        public IActionResult Edit(Guid id)
        {
            ArticleViewModel entity;

            using (IArticleService database = new ArticleService())
            {
                if (database.GetArticle(id) == null)
                    return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }

            using (IArticleService database = new ArticleService())
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ArticleDTO, ArticleViewModel>()).CreateMapper();
                var dbEntity = database.GetArticle(id);
                entity = mapper.Map<ArticleDTO, ArticleViewModel>(dbEntity);
            }

            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(ArticleViewModel model, IFormFile titleImageFile)
        {
            if (ModelState.IsValid)
            {
                if (titleImageFile != null)
                {
                    model.TitleImagePath = titleImageFile.FileName;
                    using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/", titleImageFile.FileName), FileMode.Create))
                    {
                        titleImageFile.CopyTo(stream);
                    }
                }

                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ArticleViewModel, ArticleDTO>()).CreateMapper();

                using (IArticleService database = new ArticleService())
                {
                    database.UpdateArticle(mapper.Map<ArticleViewModel, ArticleDTO>(model));
                }

                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            using (IArticleService database = new ArticleService())
            {
                database.DeleteArticle(new ArticleDTO { Id = id });
            }

            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}   
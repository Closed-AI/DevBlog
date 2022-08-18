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

namespace DevBlog.PresentationLayer
{
    public class ArticleController : Controller
    {
        private readonly IArticleService database;
        private readonly IWebHostEnvironment hostingEnvironment;

        public ArticleController(IArticleService db, IWebHostEnvironment atherHostingEnvironment)
        {
            database = db;
            hostingEnvironment = atherHostingEnvironment;
        }

        public IActionResult Edit(Guid id)
        {
            ArticleViewModel entity;

            if (id == default)
                entity = new ArticleViewModel();
            else
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ArticleDTO,ArticleViewModel>()).CreateMapper();
                var dbEntity = database.GetArticle(id);
                entity = mapper.Map<ArticleDTO,ArticleViewModel>(dbEntity);
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
                // dataManager.ServiceItems.SaveServiceItem(model);
                // реализовать логику редактирования существующей статьи

                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ArticleDTO, ArticleViewModel>()).CreateMapper();

                database.CreateArticle(mapper.Map<ArticleViewModel, ArticleDTO>(model));
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var article = database.GetArticle(id);
            database.DeleteArticle(article);

            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
﻿using ForumSystem.Data.Common.Repository;
using ForumSystem.DataModels;
using ForumSystem.Web.Infrastructure.Mapping;
using ForumSystem.Web.ViewModels.Home;
using System.Linq;
using System.Web.Mvc;

namespace ForumSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        //private IRepository<Post> posts;
        private readonly IDeletableEntityRepository<Post> posts;

        //Poor man's DI
        //public HomeController() 
        //    : this(new GenericRepository<Post>(new ApplicationDbContext()))
        //{
        //}

        public HomeController(IDeletableEntityRepository<Post> posts)
        {
            this.posts = posts;
        }

        public ActionResult Index()
        {
            //this.posts.ActualDelete(this.posts.GetById(3));
            //this.posts.SaveChanges();
            var posts = this.posts.All()
                .To<IndexBlogPostViewModel>().ToList();
            return View(posts);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
using ForumSystem.Data.Common.Repository;
using ForumSystem.DataModels;
using ForumSystem.Web.Infrastructure.Mapping;
using System.Linq;
using System.Web.Mvc;
using ForumSystem.Web.InputModels.Questions;
using ForumSystem.Web.ViewModels.Questions;
using AutoMapper.Mappers;
using ForumSystem.Web.Infrastructure;

namespace ForumSystem.Web.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IDeletableEntityRepository<Post> posts;

        private readonly ISanitizer sanitizer;

        public QuestionsController(IDeletableEntityRepository<Post> posts, ISanitizer sanitizer)
        {
            this.posts = posts;
            this.sanitizer = sanitizer;
        }

        // GET: Questions
        //questions/1800132/javascript-set-border-radius
        //questions/1800132/javascript-set-border-radius?page=2&tab=votes#tab-top
        public ActionResult Display(int id, string url, int page = 1)
        {
            var postViewModel = this.posts.All().Where(x => x.Id == id).To<QuestionDisplayViewModel>().FirstOrDefault();

            if (postViewModel == null)
            {
                return this.HttpNotFound("No such post");
            }

            return this.View(postViewModel);
        }


        //questions/tagged/javascript
        public ActionResult GetByTag(string tag)
        {
            return Content(tag);
        }

        [HttpGet]
        public ActionResult Ask()
        {
            var model = new AskInputModel();
            return View();
        }

        [HttpPost]
        public ActionResult Ask(AskInputModel input)
        {
            if (ModelState.IsValid)
            {
                var post = new Post
                {
                    Title = input.Title,
                    Content = sanitizer.Sanitize(input.Content),
                    //TODO: Tags
                    //TODO: Author
                };

                posts.Add(post);
                posts.SaveChanges();
                return RedirectToAction("Display", new { id = post.Id, url = "new"});
            }
            return View(input);
        }
    }
}
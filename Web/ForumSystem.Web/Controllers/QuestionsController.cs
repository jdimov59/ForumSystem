using ForumSystem.Data.Common.Repository;
using ForumSystem.DataModels;
using ForumSystem.Web.InputModels.Questions;
using System.Web.Mvc;

namespace ForumSystem.Web.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IDeletableEntityRepository<Post> posts;

        public QuestionsController(IDeletableEntityRepository<Post> posts)
        {
            this.posts = posts;
        }

        // GET: Questions
        //questions/1800132/javascript-set-border-radius
        //questions/1800132/javascript-set-border-radius?page=2&tab=votes#tab-top
        public ActionResult Display(int id, string url, int page = 1)
        {
            //return View();
            return Content(id + " " + url);
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
                    Content = input.Content,
                    //TODO: Tags
                    //TODO: Author
                };

                posts.Add(post);
                posts.SaveChanges();
                return RedirectToAction("Display", new { id = post.Id, url = "new URL - posle"});
            }
            return View(input);
        }
    }
}
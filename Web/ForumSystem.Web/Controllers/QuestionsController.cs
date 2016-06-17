using ForumSystem.Web.InputModels.Questions;
using System.Web.Mvc;

namespace ForumSystem.Web.Controllers
{
    public class QuestionsController : Controller
    {
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
            return Content("POST");
        }
    }
}
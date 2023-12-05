using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace deneme.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            var values = commentManager.GetCommentListWithBlog();
            
            return View(values);
        }

        public ActionResult CommentDelete(int id)
        {
            var blogvalue = commentManager.TGetById(id);
            commentManager.TDelete(blogvalue);
            return RedirectToAction("Index"); 
        }        
        public IActionResult CommentSwitchStatus(int id)
        {
            var commentToUpdate = commentManager.TGetById(id);
            commentToUpdate.CommentStatus = !commentToUpdate.CommentStatus;         
            commentManager.TUpdate(commentToUpdate);
            return RedirectToAction("Index");
        }
    }
}

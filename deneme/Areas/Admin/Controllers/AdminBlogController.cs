using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;

namespace deneme.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());

        public IActionResult Index()
        {
            var values=blogManager.GetBlogListWithCategory();

            return View(values);
        }
        public IActionResult SwitchBlogStatus(int id)
        {
            var blogToUpdate = blogManager.TGetById(id);
            blogToUpdate.BlogStatus = !blogToUpdate.BlogStatus;
            blogManager.TUpdate(blogToUpdate);
            return RedirectToAction("Index");
        }
    }
}

using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace deneme.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {    
            var writerblogid = c.Blogs.
                OrderByDescending(x => x.BlogID).
                Select(x => x.WriterID).
                Take(1).
                FirstOrDefault();

            ViewBag.blogTitle = c.Blogs.
                OrderByDescending(x => x.BlogID).
                Select(x => x.BlogTitle).
                Take(1).FirstOrDefault();
            ViewBag.writer = c.Writers.
                Where(x => x.WriterID == writerblogid).
                Select(x => x.WriterName).
                FirstOrDefault();
            return View();
        }
    }
}

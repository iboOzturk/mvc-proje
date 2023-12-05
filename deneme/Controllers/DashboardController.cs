using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace deneme.Controllers
{
    public class DashboardController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            Context c=new Context();
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).
                Select(y => y.Email).FirstOrDefault();

            var writerid=c.Writers.Where(x => x.WriterMail==usermail).
                Select(x=>x.WriterID).FirstOrDefault();
            
            ViewBag.v1=c.Blogs.Count().ToString();
            ViewBag.v2=c.Blogs.Where(x=>x.WriterID==writerid).Count();
            ViewBag.v3=c.Categories.Count().ToString();
            return View();
        }
    }
}

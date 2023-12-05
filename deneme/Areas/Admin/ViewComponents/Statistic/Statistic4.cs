using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace deneme.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4:ViewComponent
    {
        Context context = new Context();

        public IViewComponentResult Invoke()
        {
            ViewBag.userName = context.Admins.
                Where(x => x.AdminID == 1).
                Select(y => y.Name).FirstOrDefault();
            ViewBag.userImage=context.Admins.
                Where(x=>x.AdminID==1).
                Select(y => y.ImageUrl).FirstOrDefault();
            ViewBag.userDesc=context.Admins.
                Where(x=>x.AdminID==1).
                Select(y=>y.ShortDescription).FirstOrDefault();
            return View();
        }
    }
}

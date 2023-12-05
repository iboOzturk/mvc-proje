using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace deneme.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1:ViewComponent
    {
        BlogManager bm=new BlogManager(new EfBlogRepository());
        Context context = new Context();

        public IViewComponentResult Invoke()
        { 
            ViewBag.v1=bm.GetList().Count();
            ViewBag.v2=context.Contacts.Count();
            ViewBag.v3=context.Comments.Count();
            string api = "5940eca3e2213c7f0a093e8dc9e77f0a";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=bursa&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document= XDocument.Load(connection);
            ViewBag.temp=document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            return View(); 
        }
    }
}

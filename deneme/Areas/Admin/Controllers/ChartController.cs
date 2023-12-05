using deneme.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace deneme.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryClass> list=new List<CategoryClass>();
            list.Add(new CategoryClass
            {
             categoryname="Teknoloji",
             categorycount=60
            });
            list.Add(new CategoryClass
            {
                categoryname = "Yazılım",
                categorycount = 24
            });
            list.Add(new CategoryClass
            {
                categoryname = "Spor",
                categorycount = 16
            });

            return Json(new {jsonlist=list});
        }
    }
}

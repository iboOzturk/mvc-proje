using deneme.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace deneme.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterList()
        {
            var jsonWriter = JsonConvert.SerializeObject(writers);
            return Json(jsonWriter);
        }

        public IActionResult GetWriterByID(int writerid)
        {
            var findwriter=writers.FirstOrDefault(x=>x.Id == writerid);
            var jsonWriters=JsonConvert.SerializeObject(findwriter);
            return Json(jsonWriters);
        }

        [HttpPost]
        public IActionResult AddWriter(WriterClass w) 
        { 
            writers.Add(w);
            var jsonWriters= JsonConvert.SerializeObject(w);
            return Json(jsonWriters); 
        }

        public IActionResult DeleteWriter(int id)
        {
            var writer=writers.FirstOrDefault(x=> x.Id == id);
            writers.Remove(writer);
            return Json(writer);
        }
        public IActionResult UpdateWriter(WriterClass w)
        {
            var writer =writers.FirstOrDefault(x=> x.Id == w.Id);
            writer.Name= w.Name;
            var jsonWriter= JsonConvert.SerializeObject(w);
            return Json(jsonWriter);
        }

        public static List<WriterClass> writers = new List<WriterClass>
        {
           new WriterClass
           {
               Id = 1,
               Name="Ayşe"
           },
            new WriterClass
           {
               Id = 2,
               Name="Ahmet"
           },
             new WriterClass
           {
               Id = 3,
               Name="Buse"
           },
        };
    }
}

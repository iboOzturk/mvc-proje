using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace deneme.Controllers
{
    public class MessageController : Controller
    {
        MessageTwoManager mm=new MessageTwoManager(new EfMessageTwoRepository());
        Context c = new Context();

     
        public IActionResult InBox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).
                Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).
                Select(y => y.WriterID).FirstOrDefault();

            int id = writerID;
            var values=mm.GetInboxListByWriter(id);
            return View(values);
        }

        public IActionResult SendBox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).
                Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).
                Select(y => y.WriterID).FirstOrDefault();

            int id = writerID;
            var values = mm.GetSendboxListByWriter(id);
            return View(values);
        }
       
        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var value=mm.TGetById(id);
            return View(value);
        }

        public async Task<List<AppUser>> GetUsersAsync()
        {
            using (var context = new Context())
            {
                return await context.Users.ToListAsync();
            }
        }
        [HttpGet]
        public async Task<IActionResult> SendMessage() 
        {
            //KUllanıcıları DropDown'a Çektiğimiz Alan            
            List<SelectListItem> recieverUsers = (from x in await GetUsersAsync()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Email.ToString(),
                                                      Value = x.Id.ToString()
                                                  }).ToList();
            //Burası Yukarıde Çektiğimiz Verileri Front-End Tarafına Taşıyoruz.
            ViewBag.RecieverUser = recieverUsers;
            return View(); 
        }
        [HttpPost]
        public IActionResult SendMessage(MessageTwo p)
        {
            var userName = User.Identity.Name;
            var userMail = c.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var WriterID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();

            p.SenderID = WriterID;
            p.MessageStatus = true;
            p.MessageDate = DateTime.Now;
            mm.TAdd(p);

            return RedirectToAction("SendBox");

            //var username = User.Identity.Name;
            //var usermail = c.Users.Where(x => x.UserName == username).
            //    Select(y => y.Email).FirstOrDefault();
            //var writerID = c.Writers.Where(x => x.WriterMail == usermail).
            //    Select(y => y.WriterID).FirstOrDefault();
            //p.SenderID= writerID;
            //p.ReceiverID = 2;
            //p.MessageStatus = true;
            //p.MessageDate=Convert.ToDateTime(DateTime.Now.ToShortDateString());
            //mm.TAdd(p);
            //return RedirectToAction("InBox");
        }
    }
}

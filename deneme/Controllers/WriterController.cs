using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using deneme.Models;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace deneme.Controllers
{
	public class WriterController : Controller
	{
		WriterManager wm=new WriterManager(new EfWriterRepository());
		private readonly UserManager<AppUser> _userManager;
		Context c=new Context();

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
		public IActionResult Index()
		{
			var usermail = User.Identity.Name;
			ViewBag.v = usermail;			
			return View();
		}
		public IActionResult WriterProfile() 
		{
			return View();		
		}
		
		public IActionResult Test()
		{ 
			return View();
		}
		
		public PartialViewResult WriterNavBarPartial()
		{
			var username = User.Identity.Name;
            var userNameSurname = c.Users.Where(x => x.UserName == username).
                Select(y => y.NameSurname).FirstOrDefault();
            ViewBag.nameSurname=userNameSurname;

            return PartialView();
		}
		
		public PartialViewResult WriterFooterPartial()
		{
			return PartialView();
		}
		
		[HttpGet]
		//public IActionResult WriterEditProfile()
		public async Task<IActionResult> WriterEditProfile()
		{
			//Context c = new Context();
			//UserManager userManager=new UserManager(new EfUserRepository());
			//var username = User.Identity.Name;
			//var usermail = c.Users.Where(x => x.UserName == username).
			//	Select(y => y.Email).FirstOrDefault();
			////         var writerID = c.Writers.Where(x => x.WriterMail == usermail).
			////             Select(y => y.WriterID).FirstOrDefault();
			////         var writervalues = wm.TGetById(writerID);
			////return View(writervalues);

			////var values = await _userManager.FindByNameAsync(User.Identity.Name);
			////var id=c.Users.Where(x=>x.UserName== User.Identity.Name).Select(y=>y.Id).FirstOrDefault();
			//var id=c.Users.Where(x=>x.Email==usermail).Select(y => y.Id).FirstOrDefault();	
			//var values=userManager.TGetById(id);
			//return View(values);

			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			UserUpdateViewModel model = new UserUpdateViewModel();
            model.mail = values.Email;
            model.namesurname = values.NameSurname;
            model.imageurl = values.ImageUrl;
			model.username = values.UserName;

			return View(model);
		}
        
        [HttpPost]
        //public IActionResult WriterEditProfile(Writer p)
        public async Task< IActionResult> WriterEditProfile(UserUpdateViewModel model)
        {
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			values.NameSurname = model.namesurname;
			values.ImageUrl = model.imageurl;
			values.Email = model.mail;
			values.PasswordHash=_userManager.PasswordHasher.HashPassword(values,model.password);
			var result=await _userManager.UpdateAsync(values);
			return RedirectToAction("Index","Dashboard");

            //var pas1 = Request.Form["pass1"];
            //var pas2 = Request.Form["pass2"];
            //if (pas1 == pas2)
            //{
            //    p.WriterPassword = pas2;
            //    WriterValidator validationRules = new WriterValidator();
            //    ValidationResult result = validationRules.Validate(p);
            //    if (result.IsValid)
            //    {
            //        p.WriterStatus = true;
            //        p.WriterImage = "/CoreBlogTema/images/t3.jpg";
            //        wm.TUpdate(p);
            //        return RedirectToAction("Index", "Dashboard");
            //    }
            //    else
            //    {
            //        foreach (var item in result.Errors)
            //        {
            //            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //        }
            //    }
            //}
            //else
            //{
            //    ViewBag.hata = "Girdiğiniz Parolalar Uyuşmuyor!";
            //}
            //return View();       
        }

		[HttpGet]
		public IActionResult WriterAdd()
		{
			return View();
		}

        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
			Writer w=new Writer();
			if (p.WriterImage!=null)
			{
				var extension = Path.GetExtension(p.WriterImage.FileName);
				var newimagename = Guid.NewGuid() + extension;
				var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/WriterImageFiles/", newimagename);
				var stream = new FileStream(location, FileMode.Create);
				p.WriterImage.CopyTo(stream);
				//w.WriterImage = newimagename;
				w.WriterImage = "/WriterImageFiles/" + newimagename;
			}
			w.WriterMail = p.WriterMail;
			w.WriterName = p.WriterName;
			w.WriterPassword = p.WriterPassword;
			w.WriterStatus = true;
			w.WriterAbout = p.WriterAbout;
			wm.TAdd(w);
            return RedirectToAction("Index","Dashboard");
        }
    }
}

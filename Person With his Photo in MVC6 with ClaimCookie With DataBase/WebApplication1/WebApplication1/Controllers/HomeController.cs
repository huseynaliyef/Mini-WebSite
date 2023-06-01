using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;
using System.Security.Claims;
using WebApplication1.Functionaol_Methoods;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class HomeController : Controller
	{
		Improtant_Functions i = new Improtant_Functions();

        [AllowAnonymous]
        public IActionResult Login()
		{
			return View();
		}

        [AllowAnonymous]
        [HttpPost]
		public IActionResult Login(RegisteredUser r)
		{
			r.Password = i.HashPassword(r.Password);
            WebSiteContext w = new WebSiteContext();

            var item = w.RegisteredUsers.Where(x => x.Email == r.Email && x.Password == r.Password).FirstOrDefault();
			if (item != null)
			{
                var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name,item.UserName),
                    new Claim(MyClaimTypes.Email,item.Email)
                };

                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);


                HttpContext.SignInAsync(principal);

                return RedirectToAction("Index");
            }
			return View("Login");
		}

        [AllowAnonymous]
        [HttpPost]
		public IActionResult Register(RegisteredUser re)
		{
			if (ModelState.IsValid) 
			{
				WebSiteContext w = new WebSiteContext();
				RegisteredUser r = new RegisteredUser();
				r.UserName = re.UserName;
				r.Email = re.Email;
				r.Password = i.HashPassword(re.Password);
				w.RegisteredUsers.Add(r);
				w.SaveChanges();
				TempData["Message"] = "Sussecfully Registration.";
				return RedirectToAction("Login");
			}
			else
			{
				TempData["Message"] = "Unsussecfully Registration.";
				return RedirectToAction("Login");
			}
			
		}

		public IActionResult Logout()
		{
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
		}
		
		public IActionResult Index()
		{
			ViewBag.Ad = User.FindFirst(ClaimTypes.Name)?.Value;
            return View();
		}


		public IActionResult ShowDetails()
		{
			string id = Request.Query["Id"];
			ViewData["id"] = id;
			ViewBag.Ad = User.FindFirst(ClaimTypes.Name)?.Value;
			return View();
		}

		[Authorize(Roles = "Admin")]
		public IActionResult AddUsers()
		{
			return View(new Istifadeciler());
		}

		[HttpPost]
		public async Task<IActionResult> AddUsersAsync(Istifadeciler u, IFormFile Sekil)
		{
			IFormFile img = Sekil;
			if (img != null && img.Length > 0)
			{
				WebSiteContext w = new WebSiteContext();
				Istifadeciler i = new Istifadeciler();
                var fileName = $"{Path.GetFileNameWithoutExtension(img.FileName)}_{DateTime.Now.ToString("yyyyMMddHHmmss")}.jpg";

                i.Name = u.Name; i.Surname = u.Surname; i.Uni = u.Uni; i.About = u.About; i.Photo = fileName;
				w.Istifadecilers.Add(i);

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
				using (var stream = new FileStream(path, FileMode.Create))
				{
					await img.CopyToAsync(stream);
					w.SaveChanges();
					return RedirectToAction("index");
				}
			}

			return View();

		}

        [Authorize(Roles = "Admin")]
        public IActionResult UpdateUser(int id)
        {
            ViewBag.Id = id;
            
            return View(new Istifadeciler());
        }

        [HttpPost]
		public async Task<IActionResult> UpdateUserAsync(Istifadeciler u, IFormFile Sekil)
		{
			IFormFile img = Sekil;
			if (u != null)
			{
				WebSiteContext w = new WebSiteContext();
                var user = w.Istifadecilers.Find(u.Id);
				
                user.Name = u.Name;
				user.Surname = u.Surname; 
				user.Uni = u.Uni; 
				user.About = u.About;
				if(img != null)
				{
                    string OldPhotoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", $"{user.Photo}");
                    if (System.IO.File.Exists(OldPhotoPath))
                    {
                        System.IO.File.Delete(OldPhotoPath);
                    }

                    var fileName = $"{Path.GetFileNameWithoutExtension(img.FileName)}_{DateTime.Now.ToString("yyyyMMddHHmmss")}.jpg";
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await img.CopyToAsync(stream);
						user.Photo = fileName;
                    }
                }
				
				w.SaveChanges();
				return RedirectToAction("index");
				
			}

			return View();

		}



		[Authorize(Roles = "Admin")]
		public IActionResult Delete(int id)
		{
			WebSiteContext w = new WebSiteContext();
			var item = w.Istifadecilers.Find(id);
			w.Istifadecilers.Remove(item);
			w.SaveChanges();
			string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", $"{item.Photo}");

			if (System.IO.File.Exists(path))
			{
				System.IO.File.Delete(path);

			}
			return RedirectToAction("Index");
		}
	}
}

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication1.Functionaol_Methoods;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

	public class AdminController : Controller
    {
        Improtant_Functions i = new Improtant_Functions();
		
		[AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        
		[AllowAnonymous]
		[HttpPost]
		public IActionResult Login(AdminLogin a)
        {
            WebSiteContext w = new WebSiteContext();
            a.Password = i.HashPassword(a.Password);
            var item = w.AdminLogins.Where(x => x.Email == a.Email && x.Password == a.Password).FirstOrDefault();
            if(item != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "Admin"),
					new Claim(MyClaimTypes.Email,item.Email),
                    new Claim(ClaimTypes.Role,"Admin")
				};

                var useridentity = new ClaimsIdentity(claims, "AdminLogin");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);


                HttpContext.SignInAsync(principal);
                
                return RedirectToAction("Index","Home");
			
		}
            return View();
        }
    }
}

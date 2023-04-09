using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PersonelTakipSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PersonelTakipSistemi.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();

       [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Login( Admin a )
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.KullaniciAdi == a.KullaniciAdi && x.Sifre == a.Sifre);
            if(bilgiler != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,a.KullaniciAdi)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Employee");
            }
            return View();
        }
    }
}

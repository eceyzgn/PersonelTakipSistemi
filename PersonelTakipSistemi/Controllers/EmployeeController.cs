using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonelTakipSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelTakipSistemi.Controllers
{
    public class EmployeeController : Controller
    {
        Context c = new Context();

        [Authorize]
        public IActionResult Index()
        {
            var degerler = c.Employees.Include(x=>x.Departman).ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult NewEmployee()
        {
            List<SelectListItem> degerler = (from x in c.Departments.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.DepartmanAd,
                                                 Value = x.DepartmanId.ToString()
                                             }).ToList(); // = den sonra linq kullanıldı
            ViewBag.degerler = degerler;
            return View();
        }

        public IActionResult NewEmployee(Employee e)
        {
            var emp = c.Departments.Where(x => x.DepartmanId == e.Departman.DepartmanId).FirstOrDefault();
            e.Departman = emp;
            c.Employees.Add(e);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}

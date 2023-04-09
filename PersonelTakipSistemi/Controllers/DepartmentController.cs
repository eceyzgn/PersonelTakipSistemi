using Microsoft.AspNetCore.Mvc;
using PersonelTakipSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelTakipSistemi.Controllers
{
    public class DepartmentController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var degerler = c.Departments.ToList();

            return View(degerler);
        }
        public IActionResult NewDepartment()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewDepartment(Department d)
        {
            c.Departments.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult DeleteDepartment(int id)
        {
            var department = c.Departments.Find(id);
            c.Departments.Remove(department);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult GetDepartment(int id)
        {
            var department = c.Departments.Find(id);
            return View("GetDepartment", department);
        }

        public IActionResult UpdateDepartment(Department d)
        {
            var department = c.Departments.Find(d.DepartmanId);
            department.DepartmanAd = d.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DepartmentDetail(int id)
        {
            var degerler = c.Employees.Where(x => x.DepartmanId == id).ToList();
            var depAd = c.Departments.Where(x => x.DepartmanId == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.depAd = depAd;
            return View(degerler);
        }
    }
}

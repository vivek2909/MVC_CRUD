using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CRUD.Controllers
{
    public class HomeController : Controller
    {
        MVC_CRUDDBContext _Context = new MVC_CRUDDBContext();
        public ActionResult Index()
        {
            var listofData = _Context.Students.ToList();
            return View(listofData);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student model)
        {
            _Context.Students.Add(model);
           int a = _Context.SaveChanges();
            if (a > 0)
            {
                TempData["Message"] = "<script>alert('Record Create Successfully')</script>";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _Context.Students.Where(x => x.StudentId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Student std)
        {
            var data = _Context.Students.Where(x => x.StudentId == std.StudentId).FirstOrDefault();
            if (data != null)
            {
                data.StudentCity = std.StudentCity;
                data.StudentName = std.StudentName;
                data.StudentFees = std.StudentFees;
                _Context.SaveChanges();
            }

            return RedirectToAction("index");
        }

        public ActionResult Details(int id)
        {
            var data = _Context.Students.Where(x => x.StudentId == id).FirstOrDefault();
            return View(data);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = _Context.Students.Where(x => x.StudentId == id).FirstOrDefault();
            _Context.Students.Remove(data);
            _Context.SaveChanges();
            ViewBag.Message = "Record Delete Successfully";
            return RedirectToAction("Index");
        }
    }
}
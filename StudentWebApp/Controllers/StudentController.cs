using Microsoft.Ajax.Utilities;
using StudentWebApp.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentWebApp.Controllers
{
    public class StudentController : Controller
    {
        Db_TestEntities DBcontext = new Db_TestEntities();

        // GET: Student

        public ActionResult Student()
        {
            return View();

        }


        [HttpPost]
        public ActionResult AddStudent(tbl_student model)
        {
            tbl_student student = new tbl_student();

            student.Fname = model.Fname;
            student.Email = model.Email;
            student.Mobile = model.Mobile;
            student.Description = model.Description;

            DBcontext.tbl_student.Add(student);
            if (!ModelState.IsValid) { return View("Student", model); }

            else { DBcontext.SaveChanges(); }

            DBcontext.SaveChanges();
            return RedirectToAction("Student");

        }
    }
}
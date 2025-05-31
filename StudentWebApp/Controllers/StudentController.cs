using Microsoft.Ajax.Utilities;
using StudentWebApp.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

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
            else { DBcontext.SaveChanges(); ModelState.Clear(); }

            DBcontext.SaveChanges();
            return RedirectToAction("Student");

        }
        public ActionResult StudentList()
        {
            var result = DBcontext.tbl_student.ToList();
            return View(result);

        }
        public ActionResult Delete(int Id)
        {
            var result = DBcontext.tbl_student.Where(x => x.Id == Id).FirstOrDefault();

            DBcontext.tbl_student.Remove(result);
            DBcontext.SaveChanges();

            var List = DBcontext.tbl_student.ToList();
            return View("StudenList",List);

        }
    }
}
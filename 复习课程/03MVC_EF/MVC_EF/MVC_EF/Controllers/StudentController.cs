using DAL;
using DAL.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_EF.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View(StudentDal.studentsList());
        }
        public ActionResult Insert()
        {
            return View();
        }
        public ActionResult InsertModel(Student stu)
        {
            if (StudentDal.StudentInsert(stu) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            if (StudentDal.StudentDelete(id) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Update(int id)
        {
            return View(StudentDal.studentId(id));
        }
        public ActionResult UpdateModel(Student stu)
        {
            if (StudentDal.StudentUpdate(stu) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
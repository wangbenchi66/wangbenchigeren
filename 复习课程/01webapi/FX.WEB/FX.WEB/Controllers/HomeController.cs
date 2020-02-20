using FX.Dal;
using FX.Dal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FX.WEB.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult select(string name = "")
        {
            List<Student> list = Dal_Student.studentsList(name);
            JsonResult json = new JsonResult();
            json.Data = new { Data = list };
            return json;
        }
    }
}
using Dapper;
using HPIT.Oracle.Web;
using Oracle.ManagedDataAccess.Client;
using Oracle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oracle.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            string sql = "select * from CLASSBANJI c left join Stuinfo s on c.ClassID=s.CId";
            using (OracleConnection conn = DapperFactory.CrateOracleConnection())
            {
                var list = conn.Query<Stuinfo>(sql);
                return View(list);
            }

        }
        public ActionResult GetClassList()
        {
            string sql = "SELECT * FROM CLASSBANJI";
            using (OracleConnection conn = DapperFactory.CrateOracleConnection())
            {
                ViewData["classlist"] = conn.Query<CLASSBANJI>(sql).Select(w => new SelectListItem() { Text = w.ClassNAME, Value = w.ClassID.ToString() }).ToList();
                return View();
            }

        }

        public ActionResult Add()
        {
            ViewData["classlist"] = GetClassList();
            return View();

        }
        /// <summary>
        /// 添加操作
        /// </summary>
        /// <param name="stuinfo"></param>
        /// <returns></returns>
        public ActionResult AddStuinfo(Stuinfo stuinfo)
        {
            if (ModelState.IsValid)
            {
                string sql = "insert into Stuinfo(Name,Sex,Age,Email,CId,AddTime) VALUES(:Name,:Sex,:Age,:Email,:CId,:AddTime)";
                using (OracleConnection conn = DapperFactory.CrateOracleConnection())
                {
                    stuinfo.AddTime = DateTime.Now;
                    if (conn.Execute(sql,stuinfo) > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Msg = "添加失败！";
                        return View(stuinfo);
                    }
                }
            }
            else
            {
                return HttpNotFound();
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            string sql = "DELETE STUINFO WHERE ID=" + id;
            using (OracleConnection conn = DapperFactory.CrateOracleConnection())
            {
                if (conn.Execute(sql, id) < 0)
                {
                    ViewBag.Msg = "删除失败！";
                }
                return RedirectToAction("Index");
            }
        }
        public ActionResult EditModel(Stuinfo stu)
        {
            string sql = "UPDATE STUINFO set Name=:Name,Sex=:Sex,Age=:Age,Email=:Email,CId=:CId,AddTime=:AddTime where ID=:ID";
            using (OracleConnection conn = DapperFactory.CrateOracleConnection())
            {
                if (conn.Execute(sql, stu) < 0)
                {
                    ViewBag.Msg = "修改失败！";
                }
                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(int id)
        {
            string sql = "select * from CLASSBANJI c left join Stuinfo s on c.ClassID=s.CId where s.ID=" + id;
            using (OracleConnection conn = DapperFactory.CrateOracleConnection())
            {
                var list = conn.QueryFirst<Stuinfo>(sql);
                return View(list);
            }
        }
    }
}
using DAL;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_dapper.Controllers
{
    public class StudentController : Controller
    {
        private static string str = ConfigurationManager.ConnectionStrings["Student"].ToString();
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public JsonResult Stulist()
        {
            using (IDbConnection conn = new SqlConnection(str))
            {
                string sql = "select * from Student";
                List<studenModel> list = conn.Query<studenModel>(sql).ToList();
                var stu = new { Data = list };
                return Json(stu, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public int StuInsert(studenModel studenModel)
        {
            int num = 0;
            using (IDbConnection conn = new SqlConnection(str))
            {
                string sql = @"insert Student values('"+studenModel.Name+ "','" + studenModel.Sex + "')";
                num = conn.Execute(sql);
            }
            return num;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public int StuDelete(int id)
        {
            int num = 0;
            using (IDbConnection conn = new SqlConnection(str))
            {
                string sql = @"delete Student where id=@id";
                num = conn.Execute(sql,new { @id=id});
            }
            return num;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public int StuUpdate(studenModel studenModel)
        {
            int num = 0;
            using (IDbConnection conn = new SqlConnection(str))
            {
                string sql = @"update Student set Name=@name,Sex=@sex where Id=@id";
                num = conn.Execute(sql, new { @id = studenModel.Id,@name=studenModel.Name,@sex=studenModel.Sex });
            }
            return num;
        }
    }
}
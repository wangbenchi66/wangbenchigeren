using BLL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webfrom.Handler
{
    /// <summary>
    /// StudentUpdate 的摘要说明
    /// </summary>
    public class StudentUpdate : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var name = context.Request["name"];
            var sex = context.Request["sex"];
            var id = context.Request["id"];
            Student stu = new Student()
            {
                Name = name,
                Sex = sex,
                id = Convert.ToInt32(id),
            };
            var num = 0;
            if (Bll_Student.StudentUpdate(stu) > 0)
            {
                num = 1;
            }

            context.Response.Write(num);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
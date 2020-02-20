using BLL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webfrom.Handler
{
    /// <summary>
    /// StudentInsert 的摘要说明
    /// </summary>
    public class StudentInsert : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var name = context.Request["name"];
            var sex = context.Request["sex"];
            Student stu = new Student()
            {
                Name = name,
                Sex = sex,
            };
            var num = 0;
            if (Bll_Student.StudentInsert(stu)>0)
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
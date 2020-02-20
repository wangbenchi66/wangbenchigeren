using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webfrom.Handler
{
    /// <summary>
    /// StudentDelete 的摘要说明
    /// </summary>
    public class StudentDelete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var id = context.Request["id"];
            var num = 0;
            if (id!=null)
            {
               num= Bll_Student.StudentDelete(Convert.ToInt32( id));
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
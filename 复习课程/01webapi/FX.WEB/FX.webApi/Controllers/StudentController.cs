using FX.Dal;
using FX.Dal.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FX.webApi.Controllers
{
    public class StudentController : ApiController
    {
        [HttpGet]
        public object select()
        {
            var list = new { Data = Dal_Student.studentsList() };
            return list;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public object Delete(int id)
        {
            int num = 0;
            Student stu = new Student() { Id = id };
            int res = Dal_Student.Studelete(stu);
            if (res > 0)
            {
                num = res;
            }
            return Json(num);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="jObject"></param>
        /// <returns></returns>
        [HttpPost]
        public object StuInsert(JObject jObject)
        {
            //序列化与反系列
            var jsonstr = JsonConvert.SerializeObject(jObject);
            var jsonPar = JsonConvert.DeserializeObject<dynamic>(jsonstr);
            Student stu = new Student() { Name = jsonPar.name, Sex = jsonPar.sex };

            var cc = Dal_Student.insert(stu);
            return Json(cc);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="jObject"></param>
        /// <returns></returns>
        [HttpPost]
        public object StuUpdate(JObject jObject)
        {
            //序列化与反系列
            var jsonstr = JsonConvert.SerializeObject(jObject);
            var jsonPar = JsonConvert.DeserializeObject<dynamic>(jsonstr);
            Student stu = new Student() { Name = jsonPar.name, Sex = jsonPar.sex, Id = jsonPar.Cid };
            var cc = Dal_Student.update(stu);
            return Json(cc);

        }
    }
}

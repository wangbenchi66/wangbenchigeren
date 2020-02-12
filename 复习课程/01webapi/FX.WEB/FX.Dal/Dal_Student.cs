using FX.Dal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FX.Dal
{
    public class Dal_Student
    {
        public static Model1 db = new Model1();
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public static List<Student> studentsList()
        {
            var list = (from stu in db.Student select stu).ToList();
            return list;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int Studelete(Student stu)
        {
            string sql = string.Format(@"delete Student where id={0}", stu.Id);
            int res = (int)db.Database.ExecuteSqlCommand(sql);
            return res;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public static int insert(Student student)
        {
            db.Student.Add(student);
            return db.SaveChanges();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public static int update(Student student)
        {
            //db.Entry(student).State = System.Data.Entity.EntityState.Modified;
            //return db.SaveChanges();
            string sql = string.Format(@"update Student set Name='{0}',Sex='{1}' where Id={2}", student.Name, student.Sex, student.Id);
            int result = (int)db.Database.ExecuteSqlCommand(sql);
            return result;
        }
    }
}

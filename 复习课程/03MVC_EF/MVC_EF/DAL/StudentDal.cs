using DAL.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StudentDal
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public static List<Student> studentsList()
        {
            StudentModel model = new StudentModel();
            var list = (from stu in model.Student select stu).ToList();
            return list;
        }
        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Student studentId(int id)
        {
            return studentsList().FirstOrDefault(p => p.Id == id);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int StudentDelete(int id)
        {
            StudentModel db = new StudentModel();
            var stu = db.Student.FirstOrDefault(p => p.Id == id);
            db.Student.Remove(stu);
            //db.Student.Remove(studentId(id));
            return db.SaveChanges();
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
        public static int StudentInsert(Student stu)
        {
            StudentModel db = new StudentModel();
            db.Student.Add(stu);
            return db.SaveChanges();
        }
        public static int StudentUpdate(Student stu)
        {
            StudentModel db = new StudentModel();
            db.Entry(stu).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
    }
}

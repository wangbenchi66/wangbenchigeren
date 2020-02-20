using DAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Bll_Student
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public static List<Student> GetStudents(string name = "")
        {
            return Dal_Student.GetStudents(name);
        }
        
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public static int StudentInsert(Student student)
        {
            return Dal_Student.StudentInsert(student);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public static int StudentUpdate(Student student)
        {
            return Dal_Student.StudentUpdate(student);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public static int StudentDelete(int id)
        {
            return Dal_Student.StudentDelete(id);
        }

    }
}

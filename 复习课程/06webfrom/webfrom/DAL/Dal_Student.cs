using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;

namespace DAL
{

    public class Dal_Student
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public static List<Student> GetStudents(string name = "")
        {
            SqlParameter[] sqlpar = new SqlParameter[]
              {
                new SqlParameter("@name",name)
              };
            SqlDataReader sdr = sqlhelper.selectProc("StudentSselect", sqlpar);
            List<Student> list = new List<Student>();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    Student model = new Student()
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        Name = sdr["Name"].ToString(),
                        Sex = sdr["Sex"].ToString(),
                    };
                    list.Add(model);
                }
            }
            return list;
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public static int StudentInsert(Student student)
        {
            SqlParameter[] sqlpar = new SqlParameter[]
                {
                    new SqlParameter("@name",student.Name),
                    new SqlParameter("@sex",student.Sex),
                };
            return sqlhelper.NotqueryProc("StudentInsert", sqlpar);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public static int StudentUpdate(Student student)
        {
            SqlParameter[] sqlpar = new SqlParameter[]
                {
                    new SqlParameter("@name",student.Name),
                    new SqlParameter("@sex",student.Sex),
                    new SqlParameter("@id",student.id),
                };
            return sqlhelper.NotqueryProc("StudentUpdate", sqlpar);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public static int StudentDelete(int id)
        {
            SqlParameter[] sqlpar = new SqlParameter[]
                {
                    new SqlParameter("@id",id),
                };
            return sqlhelper.NotqueryProc("StudentDelete", sqlpar);
        }
    }
}

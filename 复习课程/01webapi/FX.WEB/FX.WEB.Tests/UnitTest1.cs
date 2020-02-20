using System;
using FX.Dal;
using FX.Dal.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FX.WEB.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Student stu = new Student() { Name = "11", Sex = "男",Id=1006 };
            //var cc = Dal_Student.update(stu);
            var list = new { Data = Dal_Student.studentsList() };
        }
    }
}

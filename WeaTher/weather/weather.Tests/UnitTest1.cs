using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using weatherDal;
using weatherDal.Model;

namespace weather.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //调用接口
            var data = weatherDAL.url("101220101");
            //添加城市并接受城市ID
            var cityInfo = weatherDAL.cityInsert(data.cityInfo);
            //传递城市id
            data.data.CityID = cityInfo;
            //添加城市天气
            var cityw = weatherDAL.cityweatherInsert(data.data);

        }
        [TestMethod]
        public void TestMethod2()
        {
            //var cityw = weatherDAL.cityweatherSelete(6);
            //var  city = weatherDAL.cityInfoSelete();
            //var city = weatherDAL.echartWeather();
            var cityw = weatherDAL.cityweatherSeleteList();
        }
    }
}

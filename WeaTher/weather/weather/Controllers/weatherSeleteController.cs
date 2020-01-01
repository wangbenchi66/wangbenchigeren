using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using weatherDal;

namespace weather.Controllers
{
    public class weatherSeleteController : Controller
    {
        // GET: weatherSelete
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 添加城市天气信息
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public JsonResult insert(string url)
        {
            //调用接口
            var data = weatherDAL.url(url);
            //添加城市并接受城市ID
            var cityInfo = weatherDAL.cityInsert(data.cityInfo);
            //传递城市id
            data.data.CityID = cityInfo;
            //添加城市天气
            var cityw = weatherDAL.cityweatherInsert(data.data);
            //JsonResult json = new JsonResult();
            //json.Data = new { Data = cityw, list = cityInfo };
            return Json(cityw, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 下拉框
        /// </summary>
        /// <returns></returns>
        public JsonResult cityList()
        {
            var city = weatherDAL.cityInfoSelete();
            return Json(city, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 下拉框详情
        /// </summary>
        /// <returns></returns>
        public JsonResult cityweatherSelete(int id)
        {
            var cityw =new { Data = weatherDAL.cityweatherSelete(id) };
            return Json(cityw, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 天气类型
        /// </summary>
        /// <returns></returns>
        public JsonResult echartWeather()
        {
            var list = weatherDAL.echartWeather() ;
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 天气类型条件查询
        /// </summary>
        /// <returns></returns>
        public JsonResult echartWeatherSelete(string name)
        {
            var cityw = new { Data = weatherDAL.echartWeatherSelete(name) };
            return Json(cityw, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 天气类型
        /// </summary>
        /// <returns></returns>
        public JsonResult echartFX()
        {
            var list = weatherDAL.echartFX();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 天气类型条件查询
        /// </summary>
        /// <returns></returns>
        public JsonResult echartFXSelete(string name)
        {
            var cityw = new { Data = weatherDAL.echartFXSelete(name) };
            return Json(cityw, JsonRequestBehavior.AllowGet);
        }
    }
}
using HPIT.Data.Core;
using Newtonsoft.Json;
using SuperMarketDal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weatherDal.Model;

namespace weatherDal
{
    public class weatherDAL
    {
        /// <summary>
        /// 接口
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static weatherDB url(string ID)
        {
            string url = "http://t.weather.sojson.com/api/weather/city/" + ID;
            var list = HTTPService.Get(url);
            weatherDB model = JsonConvert.DeserializeObject<weatherDB>(list);
            return model;
        }
        /// <summary>
        /// 添加信息
        /// </summary>
        /// <param name="cityweather"></param>
        /// <returns></returns>
        public static int cityweatherInsert(cityweather cityweather)
        {
            weatherModel db = new weatherModel();
            db.cityweather.Add(cityweather);
            return db.SaveChanges();
        }
        /// <summary>
        /// 查询匹配的城市id
        /// </summary>
        /// <param name="cityInfo"></param>
        /// <returns></returns>
        public static int cityInsert(cityInfo cityInfo)
        {
            weatherModel db = new weatherModel();
            cityInfo city = db.cityInfo.FirstOrDefault(p => p.citykey == cityInfo.citykey);
            if (city == null)
            {
                db.cityInfo.Add(cityInfo);
                db.SaveChanges();
                return cityInfo.CityID;
            }
            else
            {
                return city.CityID;
            }
        }
        /// <summary>
        /// 两表查询数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<weatherDB> cityweatherSelete(int id)
        {
            weatherModel db = new weatherModel();
            List<weatherDB> city = (from c in db.cityweather
                                    join b in db.forecast on c.ID equals b.ID
                                    join q in db.cityInfo on c.CityID equals q.CityID
                                    select new weatherDB { forecast = b, data = c, cityInfo = q })
                                    .Where(a => a.data.CityID == id).Take(7).ToList();
            return city;
        }
        /// <summary>
        /// 下拉框城市
        /// </summary>
        /// <returns></returns>
        public static List<cityInfo> cityInfoSelete()
        {
            weatherModel db = new weatherModel();
            List<cityInfo> city = (from c in db.cityInfo
                                   select c).ToList();
            return city;
        }
        /// <summary>
        /// 天气类型查询
        /// </summary>
        /// <returns></returns>
        public static List<EchartModel> echartWeather()
        {
            weatherModel db = new weatherModel();
            string sql = @"select COUNT(f.type) value,f.type name from forecast f  group by f.type";
            List<EchartModel> list = db.Database.SqlQuery<EchartModel>(sql).ToList();
            return list;
        }

        /// <summary>
        /// 天气类型条件查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<weatherDB> echartWeatherSelete(string name)
        {
            weatherModel db = new weatherModel();
            List<weatherDB> city = (from c in db.cityweather
                                    join b in db.forecast on c.ID equals b.ID
                                    join q in db.cityInfo on c.CityID equals q.CityID
                                    select new weatherDB { forecast = b, data = c, cityInfo = q })
                                    .Where(a => a.forecast.type == name).Take(7).ToList();
            return city;
        }
        /// <summary>
        /// 风向查询
        /// </summary>
        /// <returns></returns>
        public static List<EchartModel> echartFX()
        {
            weatherModel db = new weatherModel();
            string sql = @"select  f.fx name,COUNT(f.fx) value from forecast f  group by f.fx";
            List<EchartModel> list = db.Database.SqlQuery<EchartModel>(sql).ToList();
            return list;
        }
        /// <summary>
        /// 风向条件查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<weatherDB> echartFXSelete(string name)
        {
            weatherModel db = new weatherModel();
            List<weatherDB> city = (from c in db.cityweather
                                    join b in db.forecast on c.ID equals b.ID
                                    join q in db.cityInfo on c.CityID equals q.CityID
                                    select new weatherDB { forecast = b, data = c, cityInfo = q })
                                    .Where(a => a.forecast.fx == name).Take(7).ToList();
            return city;
        }
        /// <summary>
        /// 多查询数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<weatherDB> cityweatherSeleteList()
        {
            weatherModel db = new weatherModel();
            List<weatherDB> city = (from c in db.cityweather
                                    join b in db.forecast on c.ID equals b.ID
                                    join q in db.cityInfo on c.CityID equals q.CityID
                                    select new weatherDB { forecast = b, data = c, cityInfo=q }).Take(7).ToList();
            return city;
        }
    }
}

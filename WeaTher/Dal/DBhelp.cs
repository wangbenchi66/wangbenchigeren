using HPIT.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using weather.Models;
using Newtonsoft.Json;

namespace weather.DAL
{
    public class DBhelp
    {
        /// <summary>
        /// 请求接口
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static weatherDB url(string url)
        {
            string rul = "http://t.weather.sojson.com/api/weather/city/" + url;
            string HTTPs = HTTPService.Get(rul);
            weatherDB weatherDB = JsonConvert.DeserializeObject<weatherDB>(HTTPs);
            return weatherDB;
        }
        
    }
}
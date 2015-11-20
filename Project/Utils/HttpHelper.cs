using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using Newtonsoft.Json;

namespace Utils
{
    public class HttpHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="method">0：Request[key] 1：Request.QueryString[key] 2:Request.Form[key]</param>
        /// <returns></returns>
        public static T Request<T>(string key, int method = 0)
        {
            string value = null;
            if (method == 0)
            {
                value = HttpContext.Current.Request.Params[key];
            }
            else if (method == 1)
            {
                value = HttpContext.Current.Request.QueryString[key];
            }
            else if (method == 2)
            {
                value = HttpContext.Current.Request.Form[key];
            }

            if (value != null)
            {
                return (T)HackType(value, typeof(T));
            }
            else
            {
                if (typeof(T) == typeof(string))
                    return (T)HackType("", typeof(T));
                return default(T);
            }

        }

        public static List<T> RequestIds<T>(string ids = "ids")
        {

            string strids = HttpContext.Current.Request[ids];
            return JsonConvert.DeserializeObject<List<T>>(strids);

        }

        public static int pageStart
        {
            get
            {
                return Convert.ToInt32(HttpContext.Current.Request["start"]) + 1;
            }
        }

        public static int pageEnd
        {
            get
            {
                int pageIndex = Convert.ToInt32(HttpContext.Current.Request["page"]);
                int pageSize = Convert.ToInt32(HttpContext.Current.Request["limit"]);
                return pageIndex * pageSize;
            }
        }

        //对可空类型进行判断,前提是value不能为null和dbnull
        private static object HackType(object value, Type convertsionType)
        {
            if (convertsionType == typeof(string))
            {
                return value;
            }
            else
            {
                //判断convertsionType类型是否为泛型，因为nullable是泛型类,
                if (convertsionType.IsGenericType && convertsionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                {
                    //如果convertsionType为nullable类，声明一个NullableConverter类，该类提供从Nullable类到基础基元类型的转换
                    NullableConverter nullableConverter = new NullableConverter(convertsionType);
                    //将convertsionType转换为nullable对的基础基元类型
                    convertsionType = nullableConverter.UnderlyingType;
                }


                if (value.ToString() == "")
                {

                    return Activator.CreateInstance(convertsionType);
                }
                else
                {
                    return Convert.ChangeType(value, convertsionType);
                }
            }

        }
    }
}
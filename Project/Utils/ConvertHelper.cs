using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Utils
{
    public class ConvertHelper
    {
        public static T Get<T>(object value)
        {
            return (T)HackType(value, typeof(T));
        }

        public static object HackType(object value, Type convertsionType)
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

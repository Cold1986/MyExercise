using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CommonLibrary
{
    public class ConvertHelper
    {
        public static T ByteArrayToObject<T>(Byte[] buffer)
        {
            return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(buffer));
        }
        public static byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj));
        }

        /// <summary>
        /// object转换为decimal类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal ToDec(object obj)
        {
            decimal result = 0;
            if (obj != null)
            {
                var success = decimal.TryParse(obj.ToString(), out result);
            }
            return result;
        }
        /// <summary>
        /// object转换为int类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ToInt(object obj)
        {
            int result = 0;
            if (obj != null)
            {
                var success = int.TryParse(obj.ToString(), out result);
            }
            return result;
        }

        public static long ToLong(object obj)
        {
            long result = 0;
            if (obj != null)
            {
                var success = long.TryParse(obj.ToString(), out result);
            }
            return result;
        }

        public static DateTime ToDateTime(object obj)
        {
            DateTime result = default(DateTime);
            if (obj != null)
            {
                var success = DateTime.TryParse(obj.ToString(), out result);
            }
            return result;
        }

        public static Double ToDouble(object obj)
        {
            Double reValue;
            Double.TryParse(obj.ToString(), out reValue);
            return reValue;
        }

        /// <summary>
        /// 字符串根据分割数组转换成HashSet
        /// </summary>
        /// <typeparam name="T">Set类型</typeparam>
        /// <param name="str">字符串</param>
        /// <param name="arry">分割字符</param>
        /// <param name="function"></param>
        /// <returns></returns>
        public static HashSet<T> ToHash<T>(string str, char[] arry, Func<string, T> function)
        {
            HashSet<T> set = new HashSet<T>();
            if (!string.IsNullOrEmpty(str) && function != null)
            {
                string[] arry1 = str.Split(arry, StringSplitOptions.RemoveEmptyEntries);
                if (arry1 != null && arry1.Any())
                {
                    foreach (string str1 in arry1)
                    {
                        set.Add(function(str1));
                    }
                }
            }
            return set;
        }

        /// <summary>
        /// 将实体值赋值到指定实体中
        /// </summary>
        /// <typeparam name="To">目标类型</typeparam>
        /// <typeparam name="From">源类型</typeparam>
        /// <param name="source">源数据</param>
        /// <returns></returns>
        public static To CopyEntityFromSource<To, From>(From source)
            where To : new()
            where From : new()
        {
            To result = new To();
            if (source == null)
            {
                return result;
            }
            Type Totype = typeof(To);
            Type FromType = typeof(From);
            PropertyInfo property = null;
            foreach (PropertyInfo currentPro in FromType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                property = Totype.GetProperty(currentPro.Name);
                if (null != property)
                {
                    property.SetValue(result, currentPro.GetValue(source, null), null);
                }
            }
            return result;
        }

    }
}

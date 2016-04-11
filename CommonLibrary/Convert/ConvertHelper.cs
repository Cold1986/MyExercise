using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

        /// <summary>
        /// 实现各进制数间的转换。ConvertBase("15",10,16)表示将十进制数15转换为16进制的数。
        /// </summary>
        /// <param name="value">要转换的值,即原值</param>
        /// <param name="from">原值的进制,只能是2,8,10,16四个值。</param>
        /// <param name="to">要转换到的目标进制，只能是2,8,10,16四个值。</param>
        public static string ConvertBase(string value, int from, int to)
        {
            try
            {
                int intValue = Convert.ToInt32(value, from);  //先转成10进制
                string result = Convert.ToString(intValue, to);  //再转成目标进制
                if (to == 2)
                {
                    result = result.PadLeft(8, '0');
                }
                return result;
            }
            catch
            {

                //LogHelper.WriteTraceLog(TraceLogLevel.Error, ex.Message);
                return "0";
            }
        }

        /// <summary>
        /// 使用指定字符集将string转换成byte[]
        /// </summary>
        /// <param name="text">要转换的字符串</param>
        /// <param name="encoding">字符编码</param>
        public static byte[] StringToBytes(string text, Encoding encoding)
        {
            return encoding.GetBytes(text);
        }

        /// <summary>
        /// 使用指定字符集将byte[]转换成string
        /// </summary>
        /// <param name="bytes">要转换的字节数组</param>
        /// <param name="encoding">字符编码</param>
        public static string BytesToString(byte[] bytes, Encoding encoding)
        {
            return encoding.GetString(bytes);
        }

        /// <summary>
        /// 将byte[]转换成int
        /// </summary>
        /// <param name="data">需要转换成整数的byte数组</param>
        public static int BytesToInt32(byte[] data)
        {
            //如果传入的字节数组长度小于4,则返回0
            if (data.Length < 4)
            {
                return 0;
            }

            //定义要返回的整数
            int num = 0;

            //如果传入的字节数组长度大于4,需要进行处理
            if (data.Length >= 4)
            {
                //创建一个临时缓冲区
                byte[] tempBuffer = new byte[4];

                //将传入的字节数组的前4个字节复制到临时缓冲区
                Buffer.BlockCopy(data, 0, tempBuffer, 0, 4);

                //将临时缓冲区的值转换成整数，并赋给num
                num = BitConverter.ToInt32(tempBuffer, 0);
            }

            //返回整数
            return num;
        }

        #region CSV文件转换类
        /// <summary>
        /// 导出报表为Csv
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="strFilePath">物理路径</param>
        /// <param name="tableheader">表头</param>
        /// <param name="columname">字段标题,逗号分隔</param>
        public static bool DtToCsv(DataTable dt, string strFilePath, string tableheader, string columname)
        {
            try
            {
                if (string.IsNullOrEmpty(strFilePath))
                {
                    return false;
                }
                StreamWriter strmWriterObj = new StreamWriter(strFilePath, false, System.Text.Encoding.UTF8);
                if (!string.IsNullOrEmpty(tableheader))
                {
                    strmWriterObj.WriteLine(tableheader);
                }
                if (!string.IsNullOrEmpty(columname))
                {
                    strmWriterObj.WriteLine(columname);
                }

                string strBufferLine = string.Empty;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strBufferLine = string.Empty;
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j > 0)
                            strBufferLine += ",";
                        strBufferLine += dt.Rows[i][j].ToString();
                    }
                    strmWriterObj.WriteLine(strBufferLine);
                }
                strmWriterObj.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 将Csv读入DataTable
        /// </summary>
        /// <param name="filePath">csv文件路径</param>
        /// <param name="n">表示第n行是字段title,第n+1行是记录开始</param>
        public static DataTable CsvToDt(string filePath, int n)
        {
            DataTable dt = new DataTable();
            StreamReader reader = new StreamReader(filePath, System.Text.Encoding.UTF8, false);
            int i = 0;
            int m = 0;
            reader.Peek();
            while (reader.Peek() > 0)
            {
                m = m + 1;
                string str = reader.ReadLine();
                if (m >= n + 1)
                {
                    string[] split = str.Split(',');

                    System.Data.DataRow dr = dt.NewRow();
                    for (i = 0; i < split.Length; i++)
                    {
                        dr[i] = split[i];
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
        #endregion
    }
}

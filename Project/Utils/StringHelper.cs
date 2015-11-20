using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    public class StringHelper
    {
        /// <summary>
        /// 转化为update串 如"id,name" =>"[id]=@id,[name]=@name"
        /// </summary>
        /// <param name="fields">要修改的字段用逗号隔开，如"id,name"</param>
        /// <returns></returns>
        public static string SqlUpdateFields(string fields)
        {
            string[] arrStr = fields.Split(',');
            for (int i = 0; i < arrStr.Length; i++)
            {
                arrStr[i] = "[" + arrStr[i] + "]" + "=@" + arrStr[i];
            }
            return string.Join(",", arrStr);
        }

        /// <summary>
        /// 转化为where串 如"id,name" =>"[id]=@id AND [name]=@name"
        /// </summary>
        /// <param name="fields">用逗号隔开如"id,name"，sql语句where条件为AND</param>
        /// <returns></returns>
        public static string SqlWhereFields(string fields)
        {
            string[] arrStr = fields.Split(',');
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < arrStr.Length; i++)
            {
                sb.AppendFormat("[{0}]=@{0} AND ", arrStr[i]);
            }
            string where = sb.ToString();
            return where.Substring(0, where.Length - 5);
        }


        /// <summary>
        /// 转化为update串 如"id,name" =>"[id]=@id,[name]=@name"
        /// </summary>
        /// <param name="fields">要修改的字段用逗号隔开，如"id,name"</param>
        /// <returns></returns>
        public static string SqlUpdateFieldsForMySql(string fields)
        {
            string[] arrStr = fields.Split(',');
            for (int i = 0; i < arrStr.Length; i++)
            {
                arrStr[i] = "`" + arrStr[i] + "`" + "=@" + arrStr[i];
            }
            return string.Join(",", arrStr);
        }

        /// <summary>
        /// 转化为where串 如"id,name" =>"[id]=@id AND [name]=@name"
        /// </summary>
        /// <param name="fields">用逗号隔开如"id,name"，sql语句where条件为AND</param>
        /// <returns></returns>
        public static string SqlWhereFieldsForMySql(string fields)
        {
            string[] arrStr = fields.Split(',');
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < arrStr.Length; i++)
            {
                sb.AppendFormat("`{0}`=@{0} AND ", arrStr[i]);
            }
            string where = sb.ToString();
            return where.Substring(0, where.Length - 5);
        }

    }
}

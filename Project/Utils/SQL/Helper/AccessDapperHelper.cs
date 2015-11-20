using System.Collections.Generic;

using Dapper;
using System.Data.OleDb;
using System.Data;

namespace Utils
{
    public class AccessDapperHelper
    {
        public static OleDbConnection CreateConnection()
        {
            OleDbConnection conn = new OleDbConnection(ConnectionString.AccessConnectionString);
            conn.Open();
            return conn;
        }

        #region 执行SQL语句
        /// <summary>
        /// 执行增、删、改方法
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static int Execute(string sql, object parms = null)
        {
            using (IDbConnection conn = CreateConnection())
            {
                return conn.Execute(sql, parms);
            }
        }

        /// <summary>
        /// 得到单行单列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, object parms = null)
        {
            using (IDbConnection conn = CreateConnection())
            {
                return conn.ExecuteScalar(sql, parms);
            }
        }

        /// <summary>
        /// 得到单行单列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static T ExecuteScalar<T>(string sql, object parms = null)
        {
            using (IDbConnection conn = CreateConnection())
            {
                return conn.ExecuteScalar<T>(sql, parms);
            }
        }


        /// <summary>
        /// 查询多个数据集IEnumerable<T>
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static IEnumerable<T> Query<T>(string sql, object parms = null)
        {
            using (IDbConnection conn = CreateConnection())
            {
                return conn.Query<T>(sql, parms);
            }
        }

        #endregion
    }
}

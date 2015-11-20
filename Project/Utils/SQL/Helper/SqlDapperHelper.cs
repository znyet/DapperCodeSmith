using System.Collections.Generic;

using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace Utils
{
    public class SqlDapperHelper
    {
        public static SqlConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection(ConnectionString.SqlServerConnectionString);
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

        //多个数据集查询
        //public static void TestMuti()
        //{
        //    string sql = "select * from admins;select * from admins";
        //    using (SqlConnection conn = SqlDapperHelper.CreateConnection())
        //    {
        //        var m = conn.QueryMultiple(sql);
        //        m.Read<People>();
        //        m.Read<People>();
        //        m.Dispose();
        //    }
        //}

        #endregion

        #region 执行事务

        public static bool ExecuteTransaction(string sql, object parms = null)
        {
            using (IDbConnection conn = CreateConnection())
            {
                bool result = true;
                IDbTransaction transaction = conn.BeginTransaction();
                try
                {
                    conn.Execute(sql, parms, transaction: transaction);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    result = false;
                }
                return result;
            }
        }

        #endregion

        #region 执行存储过程

        /// <summary>
        /// 执行增、删、改方法
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static int P_Execute(string sql, object parms = null)
        {
            using (IDbConnection conn = CreateConnection())
            {
                return conn.Execute(sql, parms, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// 得到单行单列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static object P_ExecuteScalar(string sql, object parms = null)
        {
            using (IDbConnection conn = CreateConnection())
            {
                return conn.ExecuteScalar(sql, parms, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// 得到单行单列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static T P_ExecuteScalar<T>(string sql, object parms = null)
        {
            using (IDbConnection conn = CreateConnection())
            {
                return conn.ExecuteScalar<T>(sql, parms, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// 查询多个数据集IEnumerable<T>
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static IEnumerable<T> P_Query<T>(string sql, object parms = null)
        {
            using (IDbConnection conn = CreateConnection())
            {
                return conn.Query<T>(sql, parms, commandType: CommandType.StoredProcedure); 
            }
        }

        #endregion
    }
}

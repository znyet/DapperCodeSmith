using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Utils
{
    public class SqlHelper
    {
        #region 创建SqlConnection、SqlCommand对象

        /// <summary>
        /// 创建SqlConnection
        /// </summary>
        /// <returns></returns>
        public static SqlConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection(ConnectionString.SqlServerConnectionString);
            conn.Open();
            return conn;
        }

        /// <summary>
        /// 创建SqlCommand用于执行sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="con"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static SqlCommand CreateCommandText(string sql, SqlConnection connection, List<SqlParameter> parms = null)
        {
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.CommandType = CommandType.Text;
            if (parms != null)
            {
                foreach (SqlParameter parameter in parms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) && (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
            return cmd;
        }

        /// <summary>
        /// 创建SqlCommand用于执行存储过程
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="con"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static SqlCommand CreateCommandStoredProcedure(string sql, SqlConnection connection, List<SqlParameter> parms = null)
        {
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            if (parms != null)
            {
                foreach (SqlParameter parameter in parms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) && (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
            return cmd;
        }

        #endregion

        #region 执行不带参数Sql语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteNonQuery(string sql)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommandText(sql, connection))
                {
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="sql">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object ExecuteScalar(string sql)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommandText(sql, connection))
                {
                    object obj = cmd.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }

                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="sql">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static T ExecuteScalar<T>(string sql)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommandText(sql, connection))
                {
                    object obj = cmd.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return default(T);
                    }
                    else
                    {
                        return (T)obj;
                    }

                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteDataReader(string sql)
        {
            SqlConnection connection = CreateConnection();
            SqlCommand cmd = CreateCommandText(sql, connection);
            try
            {
                SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Dispose();
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                connection.Close();
                cmd.Dispose();
                throw e;
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataTable
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteDataTable(string sql)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommandText(sql, connection))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet ExecuteDataSet(string sql)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommandText(sql, connection))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        return ds;
                    }
                }
            }
        }

        #endregion

        #region 执行带参数Sql语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteNonQuery(string sql, List<SqlParameter> parms)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommandText(sql, connection, parms))
                {
                    int result = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return result;
                     
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="sql">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object ExecuteScalar(string sql, List<SqlParameter> parms)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommandText(sql, connection, parms))
                {
                    object obj = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }

                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="sql">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static T ExecuteScalar<T>(string sql, List<SqlParameter> parms)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommandText(sql, connection, parms))
                {
                    object obj = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return default(T);
                    }
                    else
                    {
                        return (T)obj;
                    }

                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteDataReader(string sql, List<SqlParameter> parms)
        {
            SqlConnection connection = CreateConnection();
            SqlCommand cmd = CreateCommandText(sql, connection, parms);
            try
            {
                SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                cmd.Dispose();
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                connection.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                throw e;
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteDataTable(string sql, List<SqlParameter> parms)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommandText(sql, connection, parms))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        cmd.Parameters.Clear();
                        return dt;
                    }
                }
            }
        }

        // <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet ExecuteDataSet(string sql, List<SqlParameter> parms)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommandText(sql, connection, parms))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        cmd.Parameters.Clear();
                        return ds;
                    }
                }
            }
        }

        #endregion

        #region 执行不带参数存储过程

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int P_ExecuteNonQuery(string sql)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommandStoredProcedure(sql, connection))
                {
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="sql">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object P_ExecuteScalar(string sql)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommandStoredProcedure(sql, connection))
                {
                    object obj = cmd.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }

                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="sql">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static T P_ExecuteScalar<T>(string sql)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommandStoredProcedure(sql, connection))
                {
                    object obj = cmd.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return default(T);
                    }
                    else
                    {
                        return (T)obj;
                    }

                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader P_ExecuteDataReader(string sql)
        {
            SqlConnection connection = CreateConnection();
            SqlCommand cmd = CreateCommandStoredProcedure(sql, connection);
            try
            {
                SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Dispose();
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                connection.Close();
                cmd.Dispose();
                throw e;
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataTable
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>DataTable</returns>
        public static DataTable P_ExecuteDataTable(string sql)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommandStoredProcedure(sql, connection))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet P_ExecuteDataSet(string sql)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommandStoredProcedure(sql, connection))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        return ds;
                    }
                }
            }
        }

        #endregion

        #region 执行带参数存储

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int P_ExecuteNonQuery(string sql, List<SqlParameter> parms)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommandStoredProcedure(sql, connection, parms))
                {
                    int result = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return result;

                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="sql">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object P_ExecuteScalar(string sql, List<SqlParameter> parms)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommandStoredProcedure(sql, connection, parms))
                {
                    object obj = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }

                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="sql">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static T P_ExecuteScalar<T>(string sql, List<SqlParameter> parms)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommandStoredProcedure(sql, connection, parms))
                {
                    object obj = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return default(T);
                    }
                    else
                    {
                        return (T)obj;
                    }

                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader P_ExecuteDataReader(string sql, List<SqlParameter> parms)
        {
            SqlConnection connection = CreateConnection();
            SqlCommand cmd = CreateCommandStoredProcedure(sql, connection, parms);
            try
            {
                SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                cmd.Dispose();
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                connection.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                throw e;
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>DataTable</returns>
        public static DataTable P_ExecuteDataTable(string sql, List<SqlParameter> parms)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommandStoredProcedure(sql, connection, parms))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        cmd.Parameters.Clear();
                        return dt;
                    }
                }
            }
        }

        // <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet P_ExecuteDataSet(string sql, List<SqlParameter> parms)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommandStoredProcedure(sql, connection, parms))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        cmd.Parameters.Clear();
                        return ds;
                    }
                }
            }
        }

        #endregion

        #region 返回一张空表
        public static DataTable ExecuteEmptyTable(string tableName)
        {
            return ExecuteDataTable(string.Format("SELECT TOP 0 * FROM [{0}]", tableName));
        }
        #endregion

        #region SqlBulkCopy

        /// <summary>
        /// 大批量插入数据(2000每批次) 
        /// 已采用整体事物控制 
        /// </summary>
        /// <param name="dt">要导入的DataTable</param>
        /// <param name="tableName">数据库中需要导入的表名</param>
        /// <param name="column">需要导入哪些字段，默认为null导入全部(注确保字段相同)</param>
        /// --SqlBulkCopyOptions.KeepIdentity  (允许插入自增主键,默认为Default使用自增主键)
        public static void BulkCopy(DataTable dt, string tableName, string column = null, bool insert_identity = false)
        {
            using (SqlConnection conn =CreateConnection())
            {
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    SqlBulkCopyOptions option = SqlBulkCopyOptions.Default;
                    if (insert_identity == true)
                    {
                        option = SqlBulkCopyOptions.KeepIdentity;
                    }
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn, option, transaction)) //SqlBulkCopyOptions.Default
                    {
                        bulkCopy.BatchSize = 2000;
                        //bulkCopy.BulkCopyTimeout = 500000;
                        bulkCopy.DestinationTableName = tableName;
                        try
                        {
                            if (column != null)
                            {

                                foreach (var item in column.Split(','))
                                {
                                    bulkCopy.ColumnMappings.Add(item, item);
                                }
                            }
                            else
                            {

                                foreach (DataColumn col in dt.Columns)
                                {
                                    bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                                }
                            }
                            bulkCopy.WriteToServer(dt);
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
            }
        }

        #endregion

        #region BulkUpdate

        /// <summary> 
        /// 批量更新数据(每批次5000) 
        /// </summary> 
        /// <param name="table"></param> 
        public static void BulkUpdate(DataTable dt, string tableName, string column = "*")
        {
            SqlConnection conn = CreateConnection();
            SqlCommand comm = conn.CreateCommand();
            //comm.CommandTimeout = 500000;
            comm.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(comm);
            SqlCommandBuilder commandBulider = new SqlCommandBuilder(adapter);
            commandBulider.ConflictOption = ConflictOption.OverwriteChanges;
            try
            {
                //设置批量更新的每次处理条数 
                adapter.UpdateBatchSize = 5000;
                adapter.SelectCommand.Transaction = conn.BeginTransaction();/////////////////开始事务 
                adapter.SelectCommand.CommandText = "select top 0 " + column + " from " + tableName;
                adapter.Update(dt.GetChanges());
                adapter.SelectCommand.Transaction.Commit();/////提交事务
            }
            catch (Exception ex)
            {
                if (adapter.SelectCommand != null && adapter.SelectCommand.Transaction != null)
                {
                    adapter.SelectCommand.Transaction.Rollback();
                }
                throw ex;
            }
            finally
            {
                conn.Close();
                comm.Dispose();
                conn.Dispose();
                adapter.Dispose();
            }
        }
        #endregion


    }
}

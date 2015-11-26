using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Utils;
using Dapper;
using TestDapper2;

namespace TestDapper2
{
    //============================================================================
    // Author: yet
    // CreateDate: 2015-11-26 02:38:37
    // Descript: 模板生成方法，对应admins表基础增、删、改、查、等方法。
    // 
    //============================================================================
    
    /// <summary>
    /// 表名:admins
    /// 描述:
    /// 主键和自增: 
    /// </summary>
    public partial class adminsDAL
    {
        public int Insert(adminsTable entity)
        {
            string sql = "INSERT INTO [admins] ([username],[pwd],[sex]) VALUES (@username,@pwd,@sex);SELECT @@IDENTITY";
            return SqlDapperHelper.ExecuteScalar<int>(sql, entity);
        }
        
        public int InsertIdentity(adminsTable entity)
        {
            string sql = "SET IDENTITY_INSERT [admins] ON;INSERT INTO [admins] ([id],[username],[pwd],[sex]) VALUES (@id,@username,@pwd,@sex);SET IDENTITY_INSERT [admins] OFF";
            return SqlDapperHelper.Execute(sql, entity);
        }
        
        public int UpdateAll(adminsTable entity, string updateFields = null)
        {
            if (updateFields == null)
            {
                updateFields = "[username]=@username,[pwd]=@pwd,[sex]=@sex";
            }
            else
            {
                updateFields = StringHelper.SqlUpdateFields(updateFields);
            }
            string sql = "UPDATE [admins] SET " + updateFields;
            return SqlDapperHelper.Execute(sql, entity);
        }
        
        public int UpdateFieldsByWhere(adminsTable entity, string whereFields, string updateFields = null)
        {
            if (updateFields == null)
            {
                updateFields = "[username]=@username,[pwd]=@pwd,[sex]=@sex";
            }
            else
            {
                updateFields = StringHelper.SqlUpdateFields(updateFields);
            }
            string where = "WHERE " + StringHelper.SqlWhereFields(whereFields);
            string sql = string.Format("UPDATE [admins] SET {0} " + where, updateFields);
            return SqlDapperHelper.Execute(sql, entity);
        }
        
        public int DeleteAll()
        {
            string sql = "DELETE FROM [admins]";
            return SqlDapperHelper.Execute(sql);
        }
        
        public int DeleteById(int id)
        {
            string sql = "DELETE FROM [admins] WHERE [id] = @id";
            return SqlDapperHelper.Execute(sql, new { id = id });
        }
        
        public int DeleteByIds(List<int> ids)
        {
            if (ids.Count == 0) return 0;
            string sql = "DELETE FROM [admins] WHERE EXISTS(SELECT 1 FROM @table as t WHERE t.id=[admins].[id])";
            return SqlDapperHelper.Execute(sql, new { table = ids.AsTableValuedParameter("type_int") });
        }
        
        public IEnumerable<T> QueryAll<T>(string returnFields = null, int top = -1, string orderBy = null)
        {
            if (returnFields == null)
            {
                returnFields = "[id],[username],[pwd],[sex]";
            }
            if (orderBy != null)
            {
                orderBy = " ORDER BY " + orderBy;
            }
            string topN = null;
            if(top != -1)
            {
               topN = " TOP " + top + " "; 
            }
            string sql = "SELECT " + topN + returnFields + " FROM [admins]" + orderBy;
            return SqlDapperHelper.Query<T>(sql);
        }
        
        public T QueryById<T>(int id, string returnFields = null)
        {
            if (returnFields == null)
            {
                returnFields = "[id],[username],[pwd],[sex]";
            }
            string sql = "SELECT " + returnFields + " FROM [admins] WHERE [id] = @id";
            return SqlDapperHelper.Query<T>(sql, new { id = id }).FirstOrDefault();
        }
        
        public IEnumerable<T> QueryByIds<T>(List<int> ids, string returnFields = null, string orderBy = null)
        {
            if (ids.Count == 0) return new List<T>();
            if (returnFields == null)
            {
                returnFields = "[id],[username],[pwd],[sex]";
            }
            if (orderBy != null)
            {
                orderBy = " ORDER BY " + orderBy;
            }
            string sql = "SELECT " + returnFields + " FROM [admins] WHERE EXISTS(SELECT 1 FROM @table as t WHERE t.id=[admins].[id])" + orderBy;
            return SqlDapperHelper.Query<T>(sql, new { table = ids.AsTableValuedParameter("type_int") } );
        }
        
        //PageInfo参数必须是dynamic par = new ExpandoObject();
        public void QueryByPage<T>(PageInfo<T> pageinfo)
        {
            if (pageinfo.ReturnFields == null)
            {
                pageinfo.ReturnFields = "[id],[username],[pwd],[sex]";
            }
            if (pageinfo.Where != null)
            {
                pageinfo.Where = "WHERE " + pageinfo.Where;
            }
            if (pageinfo.OrderBy != null)
            {
                pageinfo.OrderBy = "ORDER BY " + pageinfo.OrderBy;
            }
            else
            {
                pageinfo.OrderBy = "ORDER BY [id] DESC";
            }

            string sqlData = null;
            if (pageinfo.Skip == 0)
            {
                sqlData = string.Format("SELECT TOP {0} {1} FROM [admins] {2} {3}", pageinfo.Take, pageinfo.ReturnFields, pageinfo.Where, pageinfo.OrderBy);
            }
            else
            {
                sqlData = string.Format("SELECT TOP {3} {0} FROM (SELECT ROW_NUMBER() OVER({1}) AS Num,{0} FROM [admins] {2}) AS [T] WHERE [T].[Num]>@skip", pageinfo.ReturnFields, pageinfo.OrderBy, pageinfo.Where, pageinfo.Take);
            }
            string sql = string.Format(@"
DECLARE @total BIGINT
SET @total=(SELECT COUNT(1) FROM [admins] {0})
SELECT @total
IF(@total!=0)
	BEGIN
	  {1}
	END", pageinfo.Where, sqlData);

            using (var conn = SqlDapperHelper.CreateConnection())
            {
                Dapper.SqlMapper.GridReader Reader = null;

                if (pageinfo.Params == null)
                {
                    Reader = conn.QueryMultiple(sql, new { skip = pageinfo.Skip });
                }
                else
                {
                    pageinfo.Params.skip = pageinfo.Skip;
                    Reader = conn.QueryMultiple(sql, (object)pageinfo.Params);
                }

                pageinfo.Total = Reader.Read<long>().FirstOrDefault();
                if (pageinfo.Total != 0)
                {
                    pageinfo.Data = Reader.Read<T>();
                }
                else
                {
                    pageinfo.Data = new List<T>();
                }
                Reader.Dispose();
            }

        }
        
        
        
    }
    
}
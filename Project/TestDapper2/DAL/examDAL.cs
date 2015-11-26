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
    // CreateDate: 2015-11-26 02:32:25
    // Descript: 模板生成方法，对应exam表基础增、删、改、查、等方法。
    // 
    //============================================================================
    
    /// <summary>
    /// 表名:exam
    /// 描述:考试表
    /// 主键和自增: 
    /// </summary>
    public partial class examDAL
    {
        public long Insert(examTable entity)
        {
            string sql = "INSERT INTO [exam] ([school_id],[schoolyear_nowyear],[schoolyear_mester],[grade_section],[exam_name],[exam_time],[exam_level]) VALUES (@school_id,@schoolyear_nowyear,@schoolyear_mester,@grade_section,@exam_name,@exam_time,@exam_level);SELECT @@IDENTITY";
            return SqlDapperHelper.ExecuteScalar<long>(sql, entity);
        }
        
        public int InsertIdentity(examTable entity)
        {
            string sql = "SET IDENTITY_INSERT [exam] ON;INSERT INTO [exam] ([id],[school_id],[schoolyear_nowyear],[schoolyear_mester],[grade_section],[exam_name],[exam_time],[exam_level]) VALUES (@id,@school_id,@schoolyear_nowyear,@schoolyear_mester,@grade_section,@exam_name,@exam_time,@exam_level);SET IDENTITY_INSERT [exam] OFF";
            return SqlDapperHelper.Execute(sql, entity);
        }
        
        public int UpdateAll(examTable entity, string updateFields = null)
        {
            if (updateFields == null)
            {
                updateFields = "[school_id]=@school_id,[schoolyear_nowyear]=@schoolyear_nowyear,[schoolyear_mester]=@schoolyear_mester,[grade_section]=@grade_section,[exam_name]=@exam_name,[exam_time]=@exam_time,[exam_level]=@exam_level";
            }
            else
            {
                updateFields = StringHelper.SqlUpdateFields(updateFields);
            }
            string sql = "UPDATE [exam] SET " + updateFields;
            return SqlDapperHelper.Execute(sql, entity);
        }
        
        public int UpdateFieldsByWhere(examTable entity, string whereFields, string updateFields = null)
        {
            if (updateFields == null)
            {
                updateFields = "[school_id]=@school_id,[schoolyear_nowyear]=@schoolyear_nowyear,[schoolyear_mester]=@schoolyear_mester,[grade_section]=@grade_section,[exam_name]=@exam_name,[exam_time]=@exam_time,[exam_level]=@exam_level";
            }
            else
            {
                updateFields = StringHelper.SqlUpdateFields(updateFields);
            }
            string where = "WHERE " + StringHelper.SqlWhereFields(whereFields);
            string sql = string.Format("UPDATE [exam] SET {0} " + where, updateFields);
            return SqlDapperHelper.Execute(sql, entity);
        }
        
        public int DeleteAll()
        {
            string sql = "DELETE FROM [exam]";
            return SqlDapperHelper.Execute(sql);
        }
        
        public int DeleteById(long id)
        {
            string sql = "DELETE FROM [exam] WHERE [id] = @id";
            return SqlDapperHelper.Execute(sql, new { id = id });
        }
        
        public int DeleteByIds(List<long> ids)
        {
            if (ids.Count == 0) return 0;
            string sql = "DELETE FROM [exam] WHERE [id] IN @ids";
            return SqlDapperHelper.Execute(sql, new { ids = ids });
        }
        
        public IEnumerable<T> QueryAll<T>(string returnFields = null, int top = -1, string orderBy = null)
        {
            if (returnFields == null)
            {
                returnFields = "[id],[school_id],[schoolyear_nowyear],[schoolyear_mester],[grade_section],[exam_name],[exam_time],[exam_level]";
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
            string sql = "SELECT " + topN + returnFields + " FROM [exam]" + orderBy;
            return SqlDapperHelper.Query<T>(sql);
        }
        
        public T QueryById<T>(long id, string returnFields = null)
        {
            if (returnFields == null)
            {
                returnFields = "[id],[school_id],[schoolyear_nowyear],[schoolyear_mester],[grade_section],[exam_name],[exam_time],[exam_level]";
            }
            string sql = "SELECT " + returnFields + " FROM [exam] WHERE [id] = @id";
            return SqlDapperHelper.Query<T>(sql, new { id = id }).FirstOrDefault();
        }
        
        public IEnumerable<T> QueryByIds<T>(List<long> ids, string returnFields = null, string orderBy = null)
        {
            if (ids.Count == 0) return new List<T>();
            if (returnFields == null)
            {
                returnFields = "[id],[school_id],[schoolyear_nowyear],[schoolyear_mester],[grade_section],[exam_name],[exam_time],[exam_level]";
            }
            if (orderBy != null)
            {
                orderBy = " ORDER BY " + orderBy;
            }
            string sql = "SELECT " + returnFields + " FROM [exam] WHERE [id] IN @ids" + orderBy;
            return SqlDapperHelper.Query<T>(sql, new { ids = ids } );
        }
        
        //PageInfo参数必须是dynamic par = new ExpandoObject();
        public void QueryByPage<T>(PageInfo<T> pageinfo)
        {
            if (pageinfo.ReturnFields == null)
            {
                pageinfo.ReturnFields = "[id],[school_id],[schoolyear_nowyear],[schoolyear_mester],[grade_section],[exam_name],[exam_time],[exam_level]";
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
                sqlData = string.Format("SELECT TOP {0} {1} FROM [exam] {2} {3}", pageinfo.Take, pageinfo.ReturnFields, pageinfo.Where, pageinfo.OrderBy);
            }
            else
            {
                sqlData = string.Format("SELECT TOP {3} {0} FROM (SELECT ROW_NUMBER() OVER({1}) AS Num,{0} FROM [exam] {2}) AS [T] WHERE [T].[Num]>@skip", pageinfo.ReturnFields, pageinfo.OrderBy, pageinfo.Where, pageinfo.Take);
            }
            string sql = string.Format(@"
DECLARE @total BIGINT
SET @total=(SELECT COUNT(1) FROM [exam] {0})
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
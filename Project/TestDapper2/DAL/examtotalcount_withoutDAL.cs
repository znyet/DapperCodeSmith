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
    // CreateDate: 2015-11-26 02:31:50
    // Descript: 模板生成方法，对应examtotalcount_without表基础增、删、改、查、等方法。
    // 
    //============================================================================
    
    /// <summary>
    /// 表名:examtotalcount_without
    /// 描述:
    /// 主键和自增: 
    /// </summary>
    public partial class examtotalcount_withoutDAL
    {
        public long Insert(examtotalcount_withoutTable entity)
        {
            string sql = "INSERT INTO [examtotalcount_without] ([exam_id],[grade_class],[exam_subject],[exam_avg],[exam_stdevp],[exam_max],[exam_allpassnum],[exam_onepassnum],[exam_twopassnum],[exam_threepassnum],[exam_greatnum],[exam_passnum],[exam_allrank],[exam_onerank],[exam_tworank],[exam_threerank]) VALUES (@exam_id,@grade_class,@exam_subject,@exam_avg,@exam_stdevp,@exam_max,@exam_allpassnum,@exam_onepassnum,@exam_twopassnum,@exam_threepassnum,@exam_greatnum,@exam_passnum,@exam_allrank,@exam_onerank,@exam_tworank,@exam_threerank);SELECT @@IDENTITY";
            return SqlDapperHelper.ExecuteScalar<long>(sql, entity);
        }
        
        public int InsertIdentity(examtotalcount_withoutTable entity)
        {
            string sql = "SET IDENTITY_INSERT [examtotalcount_without] ON;INSERT INTO [examtotalcount_without] ([id],[exam_id],[grade_class],[exam_subject],[exam_avg],[exam_stdevp],[exam_max],[exam_allpassnum],[exam_onepassnum],[exam_twopassnum],[exam_threepassnum],[exam_greatnum],[exam_passnum],[exam_allrank],[exam_onerank],[exam_tworank],[exam_threerank]) VALUES (@id,@exam_id,@grade_class,@exam_subject,@exam_avg,@exam_stdevp,@exam_max,@exam_allpassnum,@exam_onepassnum,@exam_twopassnum,@exam_threepassnum,@exam_greatnum,@exam_passnum,@exam_allrank,@exam_onerank,@exam_tworank,@exam_threerank);SET IDENTITY_INSERT [examtotalcount_without] OFF";
            return SqlDapperHelper.Execute(sql, entity);
        }
        
        public int UpdateAll(examtotalcount_withoutTable entity, string updateFields = null)
        {
            if (updateFields == null)
            {
                updateFields = "[exam_id]=@exam_id,[grade_class]=@grade_class,[exam_subject]=@exam_subject,[exam_avg]=@exam_avg,[exam_stdevp]=@exam_stdevp,[exam_max]=@exam_max,[exam_allpassnum]=@exam_allpassnum,[exam_onepassnum]=@exam_onepassnum,[exam_twopassnum]=@exam_twopassnum,[exam_threepassnum]=@exam_threepassnum,[exam_greatnum]=@exam_greatnum,[exam_passnum]=@exam_passnum,[exam_allrank]=@exam_allrank,[exam_onerank]=@exam_onerank,[exam_tworank]=@exam_tworank,[exam_threerank]=@exam_threerank";
            }
            else
            {
                updateFields = StringHelper.SqlUpdateFields(updateFields);
            }
            string sql = "UPDATE [examtotalcount_without] SET " + updateFields;
            return SqlDapperHelper.Execute(sql, entity);
        }
        
        public int UpdateFieldsByWhere(examtotalcount_withoutTable entity, string whereFields, string updateFields = null)
        {
            if (updateFields == null)
            {
                updateFields = "[exam_id]=@exam_id,[grade_class]=@grade_class,[exam_subject]=@exam_subject,[exam_avg]=@exam_avg,[exam_stdevp]=@exam_stdevp,[exam_max]=@exam_max,[exam_allpassnum]=@exam_allpassnum,[exam_onepassnum]=@exam_onepassnum,[exam_twopassnum]=@exam_twopassnum,[exam_threepassnum]=@exam_threepassnum,[exam_greatnum]=@exam_greatnum,[exam_passnum]=@exam_passnum,[exam_allrank]=@exam_allrank,[exam_onerank]=@exam_onerank,[exam_tworank]=@exam_tworank,[exam_threerank]=@exam_threerank";
            }
            else
            {
                updateFields = StringHelper.SqlUpdateFields(updateFields);
            }
            string where = "WHERE " + StringHelper.SqlWhereFields(whereFields);
            string sql = string.Format("UPDATE [examtotalcount_without] SET {0} " + where, updateFields);
            return SqlDapperHelper.Execute(sql, entity);
        }
        
        public int DeleteAll()
        {
            string sql = "DELETE FROM [examtotalcount_without]";
            return SqlDapperHelper.Execute(sql);
        }
        
        public int DeleteById(long id)
        {
            string sql = "DELETE FROM [examtotalcount_without] WHERE [id] = @id";
            return SqlDapperHelper.Execute(sql, new { id = id });
        }
        
        public int DeleteByIds(List<long> ids)
        {
            if (ids.Count == 0) return 0;
            string sql = "DELETE FROM [examtotalcount_without] WHERE [id] IN @ids";
            return SqlDapperHelper.Execute(sql, new { ids = ids });
        }
        
        public IEnumerable<T> QueryAll<T>(string returnFields = null, int top = -1, string orderBy = null)
        {
            if (returnFields == null)
            {
                returnFields = "[id],[exam_id],[grade_class],[exam_subject],[exam_avg],[exam_stdevp],[exam_max],[exam_allpassnum],[exam_onepassnum],[exam_twopassnum],[exam_threepassnum],[exam_greatnum],[exam_passnum],[exam_allrank],[exam_onerank],[exam_tworank],[exam_threerank]";
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
            string sql = "SELECT " + topN + returnFields + " FROM [examtotalcount_without]" + orderBy;
            return SqlDapperHelper.Query<T>(sql);
        }
        
        public T QueryById<T>(long id, string returnFields = null)
        {
            if (returnFields == null)
            {
                returnFields = "[id],[exam_id],[grade_class],[exam_subject],[exam_avg],[exam_stdevp],[exam_max],[exam_allpassnum],[exam_onepassnum],[exam_twopassnum],[exam_threepassnum],[exam_greatnum],[exam_passnum],[exam_allrank],[exam_onerank],[exam_tworank],[exam_threerank]";
            }
            string sql = "SELECT " + returnFields + " FROM [examtotalcount_without] WHERE [id] = @id";
            return SqlDapperHelper.Query<T>(sql, new { id = id }).FirstOrDefault();
        }
        
        public IEnumerable<T> QueryByIds<T>(List<long> ids, string returnFields = null, string orderBy = null)
        {
            if (ids.Count == 0) return new List<T>();
            if (returnFields == null)
            {
                returnFields = "[id],[exam_id],[grade_class],[exam_subject],[exam_avg],[exam_stdevp],[exam_max],[exam_allpassnum],[exam_onepassnum],[exam_twopassnum],[exam_threepassnum],[exam_greatnum],[exam_passnum],[exam_allrank],[exam_onerank],[exam_tworank],[exam_threerank]";
            }
            if (orderBy != null)
            {
                orderBy = " ORDER BY " + orderBy;
            }
            string sql = "SELECT " + returnFields + " FROM [examtotalcount_without] WHERE [id] IN @ids" + orderBy;
            return SqlDapperHelper.Query<T>(sql, new { ids = ids } );
        }
        
        //PageInfo参数必须是dynamic par = new ExpandoObject();
        public void QueryByPage<T>(PageInfo<T> pageinfo)
        {
            if (pageinfo.ReturnFields == null)
            {
                pageinfo.ReturnFields = "[id],[exam_id],[grade_class],[exam_subject],[exam_avg],[exam_stdevp],[exam_max],[exam_allpassnum],[exam_onepassnum],[exam_twopassnum],[exam_threepassnum],[exam_greatnum],[exam_passnum],[exam_allrank],[exam_onerank],[exam_tworank],[exam_threerank]";
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
                sqlData = string.Format("SELECT TOP {0} {1} FROM [examtotalcount_without] {2} {3}", pageinfo.Take, pageinfo.ReturnFields, pageinfo.Where, pageinfo.OrderBy);
            }
            else
            {
                sqlData = string.Format("SELECT TOP {3} {0} FROM (SELECT ROW_NUMBER() OVER({1}) AS Num,{0} FROM [examtotalcount_without] {2}) AS [T] WHERE [T].[Num]>@skip", pageinfo.ReturnFields, pageinfo.OrderBy, pageinfo.Where, pageinfo.Take);
            }
            string sql = string.Format(@"
DECLARE @total BIGINT
SET @total=(SELECT COUNT(1) FROM [examtotalcount_without] {0})
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
                    pageinfo.Params.skip = pageinfo.Skip + 1;
                    pageinfo.Params.take = pageinfo.Take;
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
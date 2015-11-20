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
    // CreateDate: 2015-11-20 03:45:49
    // Descript: 模板生成方法，对应people表基础增、删、改、查、等方法。
    // 
    //============================================================================
    
    /// <summary>
    /// 表名:people
    /// 描述:人类表
    /// 主键和自增: 
    /// </summary>
    public partial class peopleDAL
    {
        public int Insert(peopleTable entity)
        {
            string sql = "INSERT INTO `people` (`name`,`longs`,`Times`,`decimalss`,`bools`,`tinyintsss`,`ingerssss`) VALUES (@name,@longs,@Times,@decimalss,@bools,@tinyintsss,@ingerssss);SELECT @@IDENTITY";
            return MySqlDapperHelper.ExecuteScalar<int>(sql, entity);
        }
        
        public int InsertIdentity(peopleTable entity)
        {
            string sql = "INSERT INTO `people` (`id`,`name`,`longs`,`Times`,`decimalss`,`bools`,`tinyintsss`,`ingerssss`) VALUES (@id,@name,@longs,@Times,@decimalss,@bools,@tinyintsss,@ingerssss)";
            return MySqlDapperHelper.Execute(sql, entity);
        }
        
        public int UpdateAll(peopleTable entity, string updateFields = null)
        {
            if (updateFields == null)
            {
                updateFields = "`name`=@name,`longs`=@longs,`Times`=@Times,`decimalss`=@decimalss,`bools`=@bools,`tinyintsss`=@tinyintsss,`ingerssss`=@ingerssss";
            }
            else
            {
                updateFields = StringHelper.SqlUpdateFieldsForMySql(updateFields);
            }
            string sql = "UPDATE `people` SET " + updateFields;
            return MySqlDapperHelper.Execute(sql, entity);
        }
        
        public int UpdateFieldsByWhere(string whereFields, peopleTable entity, string updateFields = null)
        {
            if (updateFields == null)
            {
                updateFields = "`name`=@name,`longs`=@longs,`Times`=@Times,`decimalss`=@decimalss,`bools`=@bools,`tinyintsss`=@tinyintsss,`ingerssss`=@ingerssss";
            }
            else
            {
                updateFields = StringHelper.SqlUpdateFieldsForMySql(updateFields);
            }
            string where = "WHERE " + StringHelper.SqlWhereFieldsForMySql(whereFields);
            string sql = string.Format("UPDATE `people` SET {0} " + where, updateFields);
            return MySqlDapperHelper.Execute(sql, entity);
        }
        
        public int DeleteAll()
        {
            string sql = "DELETE FROM `people`";
            return MySqlDapperHelper.Execute(sql);
        }
        
        public int DeleteById(int id)
        {
            string sql = "DELETE FROM `people` WHERE `id` = @id";
            return MySqlDapperHelper.Execute(sql, new { id = id });
        }
        
        public int DeleteByIds(string ids)
        {
            string sql = "DELETE FROM `people` WHERE `id` IN (" + ids + ")";
            return MySqlDapperHelper.Execute(sql);
        }
        
        public IEnumerable<peopleTable> QueryAll(string returnFields, int top = -1, string orderBy = null)
        {
            if (returnFields == "*")
            {
                returnFields = "`id`,`name`,`longs`,`Times`,`decimalss`,`bools`,`tinyintsss`,`ingerssss`";
            }
            if (orderBy != null)
            {
                orderBy = "ORDER BY " + orderBy;
            }
            string topN = null;
            if(top != -1)
            {
               topN = " LIMIT " + top + " "; 
            }
            string sql = "SELECT " + returnFields + " FROM `people` " + orderBy + topN;
            return MySqlDapperHelper.Query<peopleTable>(sql);
        }
        
        public peopleTable QueryById(string returnFields, int id)
        {
            if (returnFields == "*")
            {
                returnFields = "`id`,`name`,`longs`,`Times`,`decimalss`,`bools`,`tinyintsss`,`ingerssss`";
            }
            string sql = "SELECT " + returnFields + " FROM `people` WHERE `id` = @id";
            return MySqlDapperHelper.Query<peopleTable>(sql, new { id = id }).FirstOrDefault();
        }
        
        public IEnumerable<peopleTable> QueryByIds(string returnFields, string ids, string orderBy = null)
        {
            if (returnFields == "*")
            {
                returnFields = "`id`,`name`,`longs`,`Times`,`decimalss`,`bools`,`tinyintsss`,`ingerssss`";
            }
            if (orderBy != null)
            {
                orderBy = "ORDER BY " + orderBy;
            }
            string sql = "SELECT " + returnFields + " FROM `people` WHERE `id` IN (" + ids + ") " + orderBy;
            return MySqlDapperHelper.Query<peopleTable>(sql);
        }
    }
    
}
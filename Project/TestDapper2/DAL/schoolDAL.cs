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
    // CreateDate: 2015-11-20 03:51:16
    // Descript: 模板生成方法，对应school表基础增、删、改、查、等方法。
    // 
    //============================================================================
    
    /// <summary>
    /// 表名:school
    /// 描述:
    /// 主键和自增:无主键 无自增字段
    /// </summary>
    public partial class schoolDAL
    {
        public int Insert(schoolTable entity)
        {
            string sql = "INSERT INTO `school` (`name`,`sex`,`AddTime`,`ImInt`,`longs`,`floats`,`doubles`) VALUES (@name,@sex,@AddTime,@ImInt,@longs,@floats,@doubles);SELECT @@IDENTITY";
            return MySqlDapperHelper.Execute(sql, entity);
        }
        
        public int UpdateAll(schoolTable entity, string updateFields = null)
        {
            if (updateFields == null)
            {
                updateFields = "`name`=@name,`sex`=@sex,`AddTime`=@AddTime,`ImInt`=@ImInt,`longs`=@longs,`floats`=@floats,`doubles`=@doubles";
            }
            else
            {
                updateFields = StringHelper.SqlUpdateFieldsForMySql(updateFields);
            }
            string sql = "UPDATE `school` SET " + updateFields;
            return MySqlDapperHelper.Execute(sql, entity);
        }
        
        public int UpdateFieldsByWhere(string whereFields, schoolTable entity, string updateFields = null)
        {
            if (updateFields == null)
            {
                updateFields = "`name`=@name,`sex`=@sex,`AddTime`=@AddTime,`ImInt`=@ImInt,`longs`=@longs,`floats`=@floats,`doubles`=@doubles";
            }
            else
            {
                updateFields = StringHelper.SqlUpdateFieldsForMySql(updateFields);
            }
            string where = "WHERE " + StringHelper.SqlWhereFieldsForMySql(whereFields);
            string sql = string.Format("UPDATE `school` SET {0} " + where, updateFields);
            return MySqlDapperHelper.Execute(sql, entity);
        }
        
        public int DeleteAll()
        {
            string sql = "DELETE FROM `school`";
            return MySqlDapperHelper.Execute(sql);
        }
        
        
        public IEnumerable<schoolTable> QueryAll(string returnFields, int top = -1, string orderBy = null)
        {
            if (returnFields == "*")
            {
                returnFields = "`name`,`sex`,`AddTime`,`ImInt`,`longs`,`floats`,`doubles`";
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
            string sql = "SELECT " + returnFields + " FROM `school` " + orderBy + topN;
            return MySqlDapperHelper.Query<schoolTable>(sql);
        }
        
    }
    
}
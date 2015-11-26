using System;
using Utils;

namespace TestDapper2
{
    //============================================================================
    // Author: yet
    // CreateDate: 2015-11-26 02:38:47
    // Descript: 模板生成属性，对应admins表字段。
    // 
    //============================================================================
    
    /// <summary>
    /// 表名:admins
    /// 描述:
    /// 主键和自增: 
    /// </summary>
    public partial class adminsTable : EntityBase
    {
        /// <summary>
        /// 字段描述:
        /// 数据类型:SqlDbType.Int
        /// 数据长度:4
        /// 允许空值:False
        /// 主键
        /// 自增
        /// </summary>
        public int id { get; set; }
        
        /// <summary>
        /// 字段描述:
        /// 数据类型:SqlDbType.NVarChar
        /// 数据长度:50
        /// 允许空值:True
        /// </summary>
        public string username { get; set; }
        
        /// <summary>
        /// 字段描述:
        /// 数据类型:SqlDbType.NVarChar
        /// 数据长度:50
        /// 允许空值:True
        /// </summary>
        public string pwd { get; set; }
        
        /// <summary>
        /// 字段描述:
        /// 数据类型:SqlDbType.Int
        /// 数据长度:4
        /// 允许空值:True
        /// </summary>
        public int sex { get; set; }
        
    }
}
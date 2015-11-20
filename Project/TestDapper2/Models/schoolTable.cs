using System;
using Utils;

namespace TestDapper2
{
    //============================================================================
    // Author: yet
    // CreateDate: 2015-11-20 03:50:46
    // Descript: 模板生成属性，对应school表字段。
    // 
    //============================================================================
    
    /// <summary>
    /// 表名:school
    /// 描述:
    /// 主键和自增:无主键 无自增字段
    /// </summary>
    public partial class schoolTable : EntityBase
    {
        /// <summary>
        /// 字段描述:String
        /// 数据类型:SqlDbType.VarChar
        /// 数据长度:33
        /// 允许空值:True
        /// </summary>
        public string name { get; set; }
        
        /// <summary>
        /// 字段描述:UInt16
        /// 数据类型:SqlDbType.Bit
        /// 数据长度:0
        /// 允许空值:True
        /// </summary>
        public ushort sex { get; set; }
        
        /// <summary>
        /// 字段描述:DateTime
        /// 数据类型:SqlDbType.DateTime
        /// 数据长度:0
        /// 允许空值:True
        /// </summary>
        public DateTime AddTime { get; set; }
        
        /// <summary>
        /// 字段描述:Int32
        /// 数据类型:SqlDbType.Int
        /// 数据长度:0
        /// 允许空值:True
        /// </summary>
        public int ImInt { get; set; }
        
        /// <summary>
        /// 字段描述:Int64
        /// 数据类型:SqlDbType.BigInt
        /// 数据长度:0
        /// 允许空值:True
        /// </summary>
        public long longs { get; set; }
        
        /// <summary>
        /// 字段描述:Single
        /// 数据类型:SqlDbType.Float
        /// 数据长度:0
        /// 允许空值:True
        /// </summary>
        public float floats { get; set; }
        
        /// <summary>
        /// 字段描述:Double
        /// 数据类型:__UNKNOWN__double
        /// 数据长度:0
        /// 允许空值:True
        /// </summary>
        public double doubles { get; set; }
        

    }
}
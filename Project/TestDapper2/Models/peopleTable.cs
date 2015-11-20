using System;
using Utils;

namespace TestDapper2
{
    //============================================================================
    // Author: yet
    // CreateDate: 2015-11-20 02:27:23
    // Descript: 模板生成属性，对应people表字段。
    // 
    //============================================================================
    
    /// <summary>
    /// 表名:people
    /// 描述:
    /// 主键和自增: 
    /// </summary>
    public partial class peopleTable : EntityBase
    {
        /// <summary>
        /// 字段描述:我是id累Int32
        /// 数据类型:SqlDbType.Int
        /// 数据长度:0
        /// 允许空值:False
        /// 主键
        /// 自增
        /// </summary>
        public int id { get; set; }
        
        /// <summary>
        /// 字段描述:字名String
        /// 数据类型:SqlDbType.VarChar
        /// 数据长度:765
        /// 允许空值:True
        /// </summary>
        public string name { get; set; }
        
        /// <summary>
        /// 字段描述:大；longInt64
        /// 数据类型:SqlDbType.BigInt
        /// 数据长度:0
        /// 允许空值:True
        /// </summary>
        public long longs { get; set; }
        
        /// <summary>
        /// 字段描述:加添时间DateTime
        /// 数据类型:SqlDbType.DateTime
        /// 数据长度:0
        /// 允许空值:True
        /// </summary>
        public DateTime Times { get; set; }
        
        /// <summary>
        /// 字段描述:财钱Decimal
        /// 数据类型:SqlDbType.Decimal
        /// 数据长度:0
        /// 允许空值:True
        /// </summary>
        public decimal decimalss { get; set; }
        
        /// <summary>
        /// 字段描述:尔类型布UInt16
        /// 数据类型:SqlDbType.Bit
        /// 数据长度:0
        /// 允许空值:True
        /// </summary>
        public ushort bools { get; set; }
        
        /// <summary>
        /// 字段描述:SByte
        /// 数据类型:SqlDbType.TinyInt
        /// 数据长度:0
        /// 允许空值:True
        /// </summary>
        public sbyte tinyintsss { get; set; }
        
        /// <summary>
        /// 字段描述:String
        /// 数据类型:__UNKNOWN__longtext
        /// 数据长度:2147483647
        /// 允许空值:True
        /// </summary>
        public string ingerssss { get; set; }
        

    }
}
using System;
using Utils;

namespace TestDapper2
{
    //============================================================================
    // Author: yet
    // CreateDate: 2015-11-26 02:14:17
    // Descript: 模板生成属性，对应examtotalcount_without表字段。
    // 
    //============================================================================
    
    /// <summary>
    /// 表名:examtotalcount_without
    /// 描述:
    /// 主键和自增: 
    /// </summary>
    public partial class examtotalcount_withoutTable : EntityBase
    {
        /// <summary>
        /// 字段描述:
        /// 数据类型:SqlDbType.BigInt
        /// 数据长度:8
        /// 允许空值:False
        /// 主键
        /// 自增
        /// </summary>
        public long id { get; set; }
        
        /// <summary>
        /// 字段描述:
        /// 数据类型:SqlDbType.BigInt
        /// 数据长度:8
        /// 允许空值:True
        /// </summary>
        public long exam_id { get; set; }
        
        /// <summary>
        /// 字段描述:
        /// 数据类型:SqlDbType.NVarChar
        /// 数据长度:50
        /// 允许空值:True
        /// </summary>
        public string grade_class { get; set; }
        
        /// <summary>
        /// 字段描述:
        /// 数据类型:SqlDbType.NVarChar
        /// 数据长度:10
        /// 允许空值:True
        /// </summary>
        public string exam_subject { get; set; }
        
        /// <summary>
        /// 字段描述:
        /// 数据类型:SqlDbType.Decimal
        /// 数据长度:5
        /// 允许空值:True
        /// </summary>
        public decimal exam_avg { get; set; }
        
        /// <summary>
        /// 字段描述:
        /// 数据类型:SqlDbType.Decimal
        /// 数据长度:5
        /// 允许空值:True
        /// </summary>
        public decimal exam_stdevp { get; set; }
        
        /// <summary>
        /// 字段描述:
        /// 数据类型:SqlDbType.Decimal
        /// 数据长度:5
        /// 允许空值:True
        /// </summary>
        public decimal exam_max { get; set; }
        
        /// <summary>
        /// 字段描述:
        /// 数据类型:SqlDbType.Int
        /// 数据长度:4
        /// 允许空值:True
        /// </summary>
        public int exam_allpassnum { get; set; }
        
        /// <summary>
        /// 字段描述:
        /// 数据类型:SqlDbType.Int
        /// 数据长度:4
        /// 允许空值:True
        /// </summary>
        public int exam_onepassnum { get; set; }
        
        /// <summary>
        /// 字段描述:
        /// 数据类型:SqlDbType.Int
        /// 数据长度:4
        /// 允许空值:True
        /// </summary>
        public int exam_twopassnum { get; set; }
        
        /// <summary>
        /// 字段描述:
        /// 数据类型:SqlDbType.Int
        /// 数据长度:4
        /// 允许空值:True
        /// </summary>
        public int exam_threepassnum { get; set; }
        
        /// <summary>
        /// 字段描述:
        /// 数据类型:SqlDbType.Int
        /// 数据长度:4
        /// 允许空值:True
        /// </summary>
        public int exam_greatnum { get; set; }
        
        /// <summary>
        /// 字段描述:
        /// 数据类型:SqlDbType.Int
        /// 数据长度:4
        /// 允许空值:True
        /// </summary>
        public int exam_passnum { get; set; }
        
        /// <summary>
        /// 字段描述:
        /// 数据类型:SqlDbType.Int
        /// 数据长度:4
        /// 允许空值:True
        /// </summary>
        public int exam_allrank { get; set; }
        
        /// <summary>
        /// 字段描述:
        /// 数据类型:SqlDbType.Int
        /// 数据长度:4
        /// 允许空值:True
        /// </summary>
        public int exam_onerank { get; set; }
        
        /// <summary>
        /// 字段描述:
        /// 数据类型:SqlDbType.Int
        /// 数据长度:4
        /// 允许空值:True
        /// </summary>
        public int exam_tworank { get; set; }
        
        /// <summary>
        /// 字段描述:
        /// 数据类型:SqlDbType.Int
        /// 数据长度:4
        /// 允许空值:True
        /// </summary>
        public int exam_threerank { get; set; }
        
    }
}
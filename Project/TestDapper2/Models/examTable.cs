using System;
using Utils;

namespace TestDapper2
{
    //============================================================================
    // Author: yet
    // CreateDate: 2015-11-26 02:13:13
    // Descript: 模板生成属性，对应exam表字段。
    // 
    //============================================================================
    
    /// <summary>
    /// 表名:exam
    /// 描述:考试表
    /// 主键和自增: 
    /// </summary>
    public partial class examTable : EntityBase
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
        /// 字段描述:学校id
        /// 数据类型:SqlDbType.Int
        /// 数据长度:4
        /// 允许空值:True
        /// </summary>
        public int school_id { get; set; }
        
        /// <summary>
        /// 字段描述:当前学年
        /// 数据类型:SqlDbType.NVarChar
        /// 数据长度:20
        /// 允许空值:True
        /// </summary>
        public string schoolyear_nowyear { get; set; }
        
        /// <summary>
        /// 字段描述:当前学期
        /// 数据类型:SqlDbType.NVarChar
        /// 数据长度:30
        /// 允许空值:True
        /// </summary>
        public string schoolyear_mester { get; set; }
        
        /// <summary>
        /// 字段描述:年级
        /// 数据类型:SqlDbType.NVarChar
        /// 数据长度:4
        /// 允许空值:True
        /// </summary>
        public string grade_section { get; set; }
        
        /// <summary>
        /// 字段描述:考试名称
        /// 数据类型:SqlDbType.NVarChar
        /// 数据长度:60
        /// 允许空值:True
        /// </summary>
        public string exam_name { get; set; }
        
        /// <summary>
        /// 字段描述:考试时间
        /// 数据类型:SqlDbType.DateTime
        /// 数据长度:8
        /// 允许空值:True
        /// </summary>
        public DateTime exam_time { get; set; }
        
        /// <summary>
        /// 字段描述:考试等级
        /// 数据类型:SqlDbType.NVarChar
        /// 数据长度:50
        /// 允许空值:True
        /// </summary>
        public string exam_level { get; set; }
        
    }
}
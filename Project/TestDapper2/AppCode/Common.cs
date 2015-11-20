using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Course.Web
{
    public class Common
    {
        public static string MapPath
        {
            get
            {
                return HttpContext.Current.Server.MapPath("~/");
            }
        }

        public static string MapPathTeacher
        {
            get
            {
                return HttpContext.Current.Server.MapPath("~/excel/教师批量上传模板.xls");
            }
        }

        public static string MapPathStudent
        {
            get
            {
                return HttpContext.Current.Server.MapPath("~/excel/学生批量上传模板.xls");
            }
        }

        public static string MapPathStudentClass
        {
            get
            {
                return HttpContext.Current.Server.MapPath("~/excel/班级学生批量上传模板.xls");
            }
        }

        public static string MapPathCourse
        {
            get
            {
                return HttpContext.Current.Server.MapPath("~/excel/课程模板.xls");
            }
        }
        public static string MapPathScore
        {
            get
            {
                return HttpContext.Current.Server.MapPath("~/excel/课程成绩.xls");
            }
        }

        public static string MapPathRegularScore
        {
            get
            {
                return HttpContext.Current.Server.MapPath("~/excel/常规课成绩上传模板.xls");
            }
        }

        public static string MapPathCouseModelAdmin
        {
            get
            {
                return HttpContext.Current.Server.MapPath("~/excel/课程模板(管理员).xls");
            }
        }


        public static int GetGrade(string grade)
        {
            int g = 1;
            switch (grade)
            {
                case "初一": g = 1; break;
                case "初二": g = 2; break;
                case "初三": g = 3; break;
                case "高一": g = 4; break;
                case "高二": g = 5; break;
                case "高三": g = 6; break;
            }
            return g;
        }

        public static string GetGradeString(int grade)
        {
            string g = "初一";
            switch (grade)
            {
                case 1: g = "初一"; break;
                case 2: g = "初二"; break;
                case 3: g = "初三"; break;
                case 4: g = "高一"; break;
                case 5: g = "高二"; break;
                case 6: g = "高三"; break;
            }
            return g;
        }

        public static string GetSemesterString(int semester)
        {
            if (semester == 1)
            {
                return "上半学期";
            }
            else 
            {
                return "下半学期";
            }
        }

        public static string GetResult(object data)
        {
            var result = new { success = true, data = data };
            return JsonConvert.SerializeObject(result);
        }

        public static string GetResult2(object data)
        {
            IsoDateTimeConverter iso = new IsoDateTimeConverter();
            iso.DateTimeFormat = "yyyy-MM-dd";
            var result = new { success = true, data = data };
            return JsonConvert.SerializeObject(result, iso);
        }

        public static void ResponseFile(MemoryStream ms,string fileName)
        {
            HttpContext.Current.Response.ContentEncoding = Encoding.GetEncoding("GB2312");

            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName, Encoding.UTF8) + ".xls");
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.BinaryWrite(ms.ToArray());
            ms.Flush();
            ms.Position = 0;
            ms.Dispose();
            HttpContext.Current.Response.End();
        }
    }
}
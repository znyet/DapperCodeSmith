using System.Data;
using System.IO;
using System.Text;
using System.Web;
using Aspose.Cells;

namespace Utils
{
    public class ExcelHelper
    {
        public static DataTable ExcelToDataTable(Workbook workbook)
        {
            DataTable dt = new DataTable();
            Worksheet worksheet = workbook.Worksheets[0];

            int maxRow = worksheet.Cells.MaxDataRow + 1;
            int maxColumn = worksheet.Cells.MaxDataColumn + 1;

            for (int i = 0; i < maxColumn; i++) //第一列作为表头
            {
                dt.Columns.Add(worksheet.Cells[0, i].StringValue.Trim(), typeof(string));
            }

            for (int i = 1; i < maxRow; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < maxColumn; j++)
                {
                    dr[j] = worksheet.Cells[i, j].StringValue.Trim();
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }


        public static void ResponseExcel(Workbook workbook, string fileName)
        {
            MemoryStream ms = workbook.SaveToStream();
            HttpContext.Current.Response.ContentEncoding = Encoding.GetEncoding("GB2312");
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName, Encoding.UTF8) + ".xls");
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.BinaryWrite(ms.ToArray());
            ms.Flush();
            ms.Position = 0;
        }
    }
}
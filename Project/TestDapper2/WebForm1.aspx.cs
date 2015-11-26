using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dapper;
using Newtonsoft.Json;
using Utils;

namespace TestDapper2
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            //dynamic par = new ExpandoObject();
        }
        

        protected void Button1_Click(object sender, EventArgs e)
        {
           


        }
        //examtotalcount_withoutDAL dal = new examtotalcount_withoutDAL();
        examDAL dal = new examDAL();
        protected void Button2_Click(object sender, EventArgs e)
        {
            dynamic d = new ExpandoObject();
            d.id = 7793;

            PageInfo<examTable> pageinfo = new PageInfo<examTable>();
            pageinfo.Skip = 28;
            pageinfo.Take = 123;
            pageinfo.OrderBy = "id";
            //pageinfo.ReturnFields = "id";
            //pageinfo.Where = "id>=@id";
            pageinfo.Params = d;

            dal.QueryByPage<examTable>(pageinfo);
            Response.Write(pageinfo.Total);
            Response.Write(JsonConvert.SerializeObject(pageinfo.Data));
            Response.Write(pageinfo.Data.Count());

        }
    }
}
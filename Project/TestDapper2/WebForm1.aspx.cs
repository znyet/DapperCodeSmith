using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
        peopleDAL _peopleDAL = new peopleDAL();

        schoolDAL _schoolDAL = new schoolDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            peopleTable people = new peopleTable();
            people.id = 2;
            people.name = "111";
            people.longs = 1;
            people.decimalss = 80.235M;
            people.bools = 1;
            people.tinyintsss = 9;
            people.ingerssss = "哈哈";
            people.Times = DateTime.Now;
            //_peopleDAL.InsertIdentity(people);

            schoolTable school = new schoolTable();
            school.AddTime = DateTime.Now;
            school.ImInt = 1;
            school.floats = 2;
            school.doubles = 3;
            school.name = "我是MySql";
            school.sex = 1;
            _schoolDAL.Insert(school);

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            IEnumerable<schoolTable> list = _schoolDAL.QueryAll("*",2);

            Response.Write(JsonConvert.SerializeObject(list));
        }
    }
}
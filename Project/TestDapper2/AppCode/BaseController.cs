using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Course.Web
{
    [Sessions]
    public class BaseController : Controller
    {


        protected ContentResult JsonStringRseult(object data = null)
        {
            var result = new { success = true, data = data };
            return Content(JsonConvert.SerializeObject(result));
        }

        protected ContentResult JsonStringRseult2(object data = null)
        {
            IsoDateTimeConverter iso = new IsoDateTimeConverter();
            iso.DateTimeFormat = "yyyy-MM-dd";
            var result = new { success = true, data = data };
            return Content(JsonConvert.SerializeObject(result,iso));
        }
    }
}
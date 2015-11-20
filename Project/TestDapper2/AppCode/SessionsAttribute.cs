using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Course.Web
{
    public class SessionsAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            
            //if (SessionHelper.exist == false)
            //{
            //    HttpContext.Current.Response.ContentType = "text/html";
            //    HttpContext.Current.Response.AddHeader("sessionstatus", "timeout");
            //    HttpContext.Current.Response.End();
            //}
        }
    }
}
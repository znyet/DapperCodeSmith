using System;
using System.Reflection;
using System.Text;
using System.Web;
using log4net;

namespace Utils
{

    public class LogHelper
    {
        private ILog logger;

        public LogHelper(ILog log)
        {
            this.logger = log;
        }

        public void Info(object message)
        {
            this.logger.Info(message);
        }

        public void Info(object message, Exception e)
        {
            this.logger.Info(message, e);
        }

        public void Debug(object message)
        {
            this.logger.Debug(message);
        }

        public void Debug(object message, Exception e)
        {
            this.logger.Debug(message, e);
        }

        public void Warming(object message)
        {
            this.logger.Warn(message);
        }

        public void Warming(object message, Exception e)
        {
            this.logger.Warn(message, e);
        }

        public void Error(object message)
        {
            this.logger.Error(message);
        }

        public void Error(object message, Exception e)
        {
            this.logger.Error(message, e);
        }

        public void Fatal(object message)
        {
            this.logger.Fatal(message);
        }

        public void Fatal(object message, Exception e)
        {
            this.logger.Fatal(message, e);
        }

        public static void LogStart()
        {
            log4net.Config.XmlConfigurator.Configure();
            LogHelper log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            log.Info("系统启动:" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
        }

        public static void LogStop()
        {
            LogHelper log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            log.Info("系统停止:" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
        }

        public static void LogInit()
        {
            Exception ex = HttpContext.Current.Server.GetLastError(); //实际出现的异常

            LogHelper log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

            if (ex != null)
            {
                Exception iex = ex.InnerException; //实际发生的异常
                if (iex != null)
                {
                    ex = iex;
                }

                HttpException httpError = ex as HttpException; //http异常


                //ASP.NET的400与404错误不记录日志，并都以自定义404页面响应
                if (httpError != null)
                {
                    var httpCode = httpError.GetHttpCode();
                    if (httpCode == 400 || httpCode == 404)
                    {

                        HttpContext.Current.Response.StatusCode = 404;//在IIS中配置自定义404页面
                        //Server.ClearError();
                        return;
                    }

                }

                //对于路径错误不记录日志，并都以自定义404页面响应
                if (ex.TargetSite.ReflectedType == typeof(System.IO.Path))
                {
                    HttpContext.Current.Response.StatusCode = 404;
                    //Server.ClearError();
                    return;
                }



                var queryString = HttpContext.Current.Request.QueryString; //get参数
                StringBuilder sbQueryString = new StringBuilder();
                sbQueryString.Append(queryString.Count + "个");
                foreach (var key in queryString.AllKeys)
                {
                    sbQueryString.Append("\r\n");
                    sbQueryString.AppendFormat("{0}:{1}", key, queryString[key]);
                }


                var form = HttpContext.Current.Request.Form; //post参数
                StringBuilder sbForm = new StringBuilder();
                sbForm.Append(form.Count + "个");
                foreach (var key in form.AllKeys)
                {
                    sbForm.Append("\r\n");
                    sbForm.AppendFormat("{0}:{1}", key, form[key]);
                }


                HttpFileCollection files = HttpContext.Current.Request.Files; //文件
                StringBuilder sbFile = new StringBuilder();
                sbFile.Append(files.Count + "个");
                if (files.Count != 0)
                {
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFile file = files[i];
                        sbFile.Append("\r\n");
                        sbFile.AppendFormat("文件名：{0}", file.FileName);
                    }
                }


                StringBuilder sb = new StringBuilder();
                sb.Append("\r\n错误消息：" + ex.Message);
                sb.Append("\r\n异常页面：" + HttpContext.Current.Request.RawUrl);
                sb.Append("\r\n请求方式：" + HttpContext.Current.Request.HttpMethod);
                sb.Append("\r\n");
                sb.Append("\r\nGET参数：" + sbQueryString.ToString());
                sb.Append("\r\n");
                sb.Append("\r\nPOST参数：" + sbForm.ToString());
                sb.Append("\r\n");
                sb.Append("\r\n上传文件：" + sbFile.ToString());
                sb.Append("\r\n");
                sb.Append("\r\n源错误：" + ex.Source);
                sb.Append("\r\n堆栈信息：" + ex.StackTrace);
                sb.Append("\r\n堆栈跟踪：" + ex.TargetSite);
                sb.Append("\r\n");
                sb.Append("\r\n\r\n===============================================");

                log.Error(sb.ToString());
            }
        }

        public class LogFactory
        {
            static LogFactory()
            {
            }

            public static LogHelper GetLogger(Type type)
            {
                return new LogHelper(LogManager.GetLogger(type));
            }

            public static LogHelper GetLogger(string str)
            {
                return new LogHelper(LogManager.GetLogger(str));
            }
        }



    }
}
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using blqw;

namespace Utils
{
    public class EntityBase
    {

        public void LoadData(int method = 0)
        {
            NameValueCollection nvc = null;
            switch (method)
            {
                case 0: nvc = HttpContext.Current.Request.Params; break;
                case 1: nvc = HttpContext.Current.Request.Form; break;
                case 2: nvc = HttpContext.Current.Request.QueryString; break;
            }

            if (nvc.Count != 0)
            {
                var ti = TypesHelper.GetTypeInfo(this.GetType()); //缓存中获取
                var li = ti.IgnoreCaseLiteracy;

                foreach (var key in nvc.AllKeys)
                {
                    var item = key.ToLower();
                    if (li.Property.Names.Contains(item))
                    {
                        string value = nvc[item];
                        if (!string.IsNullOrEmpty(value))
                        {
                            li.Property[item].SetValue(this, value);
                        }
                        else
                        {
                            if (li.Property[item].GetType() == typeof(string))
                            {
                                li.Property[item].SetValue(this, "");
                            }
                        }
                    }

                }
            }
        }

    }
}

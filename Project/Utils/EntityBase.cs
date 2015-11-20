using System.Collections.Generic;
using System.Web;
using blqw;

namespace Utils
{
    public class EntityBase
    {
        public void LoadQueryString()
        {
            var forms = HttpContext.Current.Request.QueryString;
            if (forms.Count != 0)
            {
                var ti = TypesHelper.GetTypeInfo(this.GetType()); //缓存中获取
                var li = ti.IgnoreCaseLiteracy;

                foreach (var key in forms.AllKeys)
                {
                    var item = key.ToLower();
                    if (li.Property.Names.Contains(item))
                    {
                        string value = forms[item];
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

        public void LoadForm()
        {
            var forms = HttpContext.Current.Request.Form;
            if (forms.Count != 0)
            {

                var ti = TypesHelper.GetTypeInfo(this.GetType()); //缓存中获取
                var li = ti.IgnoreCaseLiteracy;

                foreach (var key in forms.AllKeys)
                {
                    var item = key.ToLower();
                    if (li.Property.Names.Contains(item))
                    {
                        string value = forms[item];
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

        public void Load()
        {
            var forms = HttpContext.Current.Request.Params;
            if (forms.Count != 0)
            {
                var ti = TypesHelper.GetTypeInfo(this.GetType()); //缓存中获取
                var li = ti.IgnoreCaseLiteracy;

                foreach (var key in forms.AllKeys)
                {
                    var item = key.ToLower();
                    if (li.Property.Names.Contains(item))
                    {
                        string value = forms[item];
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

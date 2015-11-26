using System.Collections.Generic;

namespace Utils
{
    public class PageInfo<T>
    {
        public PageInfo(int PageSize = 10)
        {
            this.Take = PageSize;
        }

        /// <summary>
        /// 跳过第几条记录
        /// </summary>
        public int Skip { get; set; }

        /// <summary>
        /// 选择几条记录，也就是页码
        /// </summary>
        public int Take { get; set; }

        /// <summary>
        /// 返回字段，用逗号隔开
        /// </summary>
        public string ReturnFields { get; set; }

        /// <summary>
        /// 除了Access数据库，其它数据库参数必须是dynamic par = new ExpandoObject();
        /// </summary>
        public dynamic Params { get; set; }

        /// <summary>
        /// 如1=1 and name=@name，这边不必带WHERE
        /// </summary>
        public string Where { get; set; }

        /// <summary>
        /// 如Id desc,Name asc，这边不必带ORDER BY
        /// </summary>
        public string OrderBy { get; set; }

        /// <summary>
        /// 返回值，总记录数
        /// </summary>
        public long Total { get; set; } //总记录数

        /// <summary>
        /// 返回值，总记录数
        /// </summary>
        public IEnumerable<T> Data;

        public void LoadPage(string page = "page", string pageSize = "pageSize")
        {

            int PageSize = HttpHelper.Request<int>(pageSize);
            if (PageSize != 0)
            {
                this.Take = PageSize;
            }

            int Page = HttpHelper.Request<int>(page);
            if (Page > 0)
            {
                this.Skip = (Page - 1) * this.Take;
            }


        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ABP.TPLMS.Web.Models.Orgs
{

    /// <summary>
    /// 构建Json数据源的数据格式，属性有id,test,children,这里名字不能够更改否则不能够读取出来

    /// </summary>
    public class TreeJsonViewModel
    {

        /// <summary>
        /// ID
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// 子类
        /// </summary>
        public List<TreeJsonViewModel> children { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        public int parentId { get; set; }
        public string url { get; set; }
        public string state { get; set; }
    }

}
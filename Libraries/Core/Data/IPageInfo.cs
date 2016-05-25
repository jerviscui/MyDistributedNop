using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public interface IPageInfo
    {
        /// <summary>
        /// Starting from 0
        /// </summary>
        int PageIndex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        int PageSize { get; set; }
    }
}

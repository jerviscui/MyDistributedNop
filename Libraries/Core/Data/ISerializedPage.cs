using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public interface ISerializedPage<T> where T : class, new()
    {
        /// <summary>
        /// Data collection
        /// </summary>
        IList<T> Datas { get; }

        /// <summary>
        /// Index starting from 0
        /// </summary>
        uint PageIndex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        uint PageSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        uint TotalCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        uint TotalPage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        bool HasNextpage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        bool HasPrevpage { get; set; }
    }
}

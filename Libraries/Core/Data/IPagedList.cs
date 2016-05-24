using System.Collections.Generic;

namespace Core.Data
{
    public interface IPagedList<T> : IList<T>
    {
        /// <summary>
        /// Index starting from 0
        /// </summary>
        uint PageIndex { get; }

        /// <summary>
        /// 
        /// </summary>
        uint PageSize { get; }

        /// <summary>
        /// 
        /// </summary>
        uint TotalCount { get; }

        /// <summary>
        /// 
        /// </summary>
        uint TotalPage { get; }

        /// <summary>
        /// 
        /// </summary>
        bool HasNextpage { get; }

        /// <summary>
        /// 
        /// </summary>
        bool HasPrevpage { get; }
    }
}

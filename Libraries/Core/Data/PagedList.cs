using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Data
{
    public class PagedList<T> : List<T>, IPagedList<T> where T : class, new()
    {
        #region Ctor

        public PagedList(IEnumerable<T> list, uint pageIndex, uint pageSize, uint total)
        {
            this.AddRange(list);

            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.TotalCount = total;

            InitProperties();
        }
        
        public PagedList(IOrderedQueryable<T> query, int pageIndex, int pageSize)
        {
            this.PageIndex = (uint)pageIndex;
            this.PageSize = (uint)pageSize;
            this.TotalCount = (uint)query.Count();

            var list = query.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            this.AddRange(list);

            InitProperties();
        }

        #endregion

        #region Private

        private void InitProperties()
        {
            this.TotalPage = ((PageSize - 1) + TotalCount) / PageSize;
            this.HasPrevpage = PageIndex > 0;
            this.HasNextpage = PageIndex < TotalPage - 1;
        }
        #endregion

        /// <summary>
        /// Index starting from 0
        /// </summary>
        public uint PageIndex { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public uint PageSize { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public uint TotalCount { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public uint TotalPage { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public bool HasNextpage { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public bool HasPrevpage { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public class PageInfo : IPageInfo
    {
        #region Fields

        private int _pageIndex;

        private int _pageSize;
        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public PageInfo(int pageIndex, int pageSize)
        {
            _pageIndex = pageIndex;
            _pageSize = pageSize;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Starting from 0
        /// </summary>
        public int PageIndex
        {
            get
            {
                return _pageIndex;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("PageIndex", "Minimum is 0");
                }
                _pageIndex = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("PageSize", "Minimum is 1");
                }
                _pageSize = value;
            }
        }
        #endregion

        #region Private

        #endregion

        #region Methods

        #endregion
    }
}

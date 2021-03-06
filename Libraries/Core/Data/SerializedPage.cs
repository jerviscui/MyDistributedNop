﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    [Serializable]
    [DataContract]
    public class SerializedPage<T> : ISerializedPage<T> where T : class, new()
    {
        #region Ctor
        
        public SerializedPage(IEnumerable<T> list, uint pageIndex, uint pageSize, uint total)
        {
            Datas = list.ToList();

            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.TotalCount = total;

            InitProperties();
        }

        public SerializedPage(IOrderedQueryable<T> query, int pageIndex, int pageSize)
        {
            this.PageIndex = (uint)pageIndex;
            this.PageSize = (uint)pageSize;
            this.TotalCount = (uint)query.Count();

            var list = query.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            Datas = list;

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

        #region Properties
        /// <summary>
        /// Data collection
        /// </summary>
        [DataMember]
        public IList<T> Datas { get; set; }

        /// <summary>
        /// Index starting from 0
        /// </summary>
        [DataMember]
        public uint PageIndex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public uint PageSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public uint TotalCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public uint TotalPage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public bool HasNextpage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public bool HasPrevpage { get; set; }
        #endregion
    }
}

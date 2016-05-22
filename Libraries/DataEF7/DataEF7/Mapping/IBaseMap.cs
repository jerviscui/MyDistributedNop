using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace DataEF7.Mapping
{
    public interface IBaseMap
    {
        /// <summary>
        /// Model creating event
        /// </summary>
        /// <param name="builder"></param>
        void OnModelCreating(ModelBuilder builder);
    }
}

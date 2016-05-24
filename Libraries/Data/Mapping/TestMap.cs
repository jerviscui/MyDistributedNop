using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;

namespace Data.Mapping
{
    public class TestMap : BaseMap<Test>
    {
        #region Fields

        #endregion

        #region Ctor

        public TestMap()
        {
            this.Property(o => o.Timespan).HasColumnOrder(int.MaxValue - 1);
            this.Property(o => o.IsDelete).HasColumnOrder(int.MaxValue - 2);
        }
        #endregion

        #region Properties

        #endregion

        #region Private

        #endregion

        #region Methods

        #endregion
    }
}

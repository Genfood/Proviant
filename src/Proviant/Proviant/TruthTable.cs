using System;
using System.Collections.Generic;

namespace Proviant
{
    public class TruthTable
    {
        public TruthTable()
        {
            TruthRows = new List<TruthRow>();
        }

        #region properties
        public List<TruthRow> TruthRows { get; set; }
        public int Colums
        {
            get
            {
                if (TruthRows.Count > 0)
                {
                    if (TruthRows[0].Operands.Count > 0)
                    {
                        return TruthRows[0].Operands.Count + 1;
                    }
                }

                return 0;
            }
        }
        #endregion
    }
}

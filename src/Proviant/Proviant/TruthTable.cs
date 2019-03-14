using System;
using System.Collections.Generic;

namespace Proviant
{
    /// <summary>
    /// Truth table.
    /// </summary>
    public class TruthTable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Proviant.TruthTable"/> class.
        /// </summary>
        public TruthTable()
        {
            TruthRows = new List<TruthRow>();
        }

        #region properties
        /// <summary>
        /// Gets or sets the truth rows.
        /// </summary>
        /// <value>The truth rows.</value>
        public List<TruthRow> TruthRows { get; set; }

        /// <summary>
        /// The total amount of colums. 
        /// </summary>
        /// <value>Colums count.</value>
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

        /// <summary>
        /// The total amount of rows. 
        /// </summary>
        /// <value>Rows count.</value>
        public int Rows
        {
            get
            {
                return TruthRows.Count;
            }
        }
        #endregion
    }
}

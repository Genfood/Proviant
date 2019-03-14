using System.Collections.Generic;

namespace Proviant
{
    /// <summary>
    /// Truth row.
    /// </summary>
    public class TruthRow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Proviant.TruthRow"/> class.
        /// </summary>
        public TruthRow()
        {
            Operands = new Dictionary<string, bool>();
        }

        #region properties
        /// <summary>
        /// Gets or sets the operands.
        /// </summary>
        /// <value>The operands.</value>
        public Dictionary<string, bool> Operands { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Proviant.TruthRow"/> evaluated result.
        /// </summary>
        /// <value><c>true</c> if evaluated result; otherwise, <c>false</c>.</value>
        public bool EvaluatedResult { get; set; }
        #endregion
    }


}
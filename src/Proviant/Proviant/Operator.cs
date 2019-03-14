using System;
using System.Collections.Generic;

namespace Proviant
{
    /// <summary>
    /// Operator.
    /// </summary>
    public abstract class Operator<OperandType> : IOperator
    {
        #region properties
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the alternative names.
        /// </summary>
        /// <value>The alternative names.</value>
        public List<string> AlternativeNames { get; set; }

        /// <summary>
        /// Gets or sets the priority.
        /// </summary>
        /// <value>The priority.</value>
        public int Priority { get; set; }
        #endregion
    }
}

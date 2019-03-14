using System.Collections.Generic;

namespace Proviant
{
    /// <summary>
    /// Operator.
    /// </summary>
    public interface IOperator
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the alternative names.
        /// </summary>
        /// <value>The alternative names.</value>
        List<string> AlternativeNames { get; set; }

        /// <summary>
        /// Gets or sets the priority.
        /// Higher priority is more important and will be calculate first.
        /// </summary>
        /// <value>The priority.</value>
        int Priority { get; set; }
    }
}
using System;
namespace Proviant
{
    /// <summary>
    /// Unary operator.
    /// </summary>
    public class UnaryOperator<OperandType> : Operator<OperandType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Proviant.UnaryOperator`1"/> class.
        /// </summary>
        /// <param name="calculate">The function to calculate this operator.</param>
        public UnaryOperator(Func<OperandType, OperandType> calculate)
        {
            this.Calculate = calculate;
        }

        #region properties
        /// <summary>
        /// Gets the calculation function.
        /// </summary>
        /// <value>The calculate.</value>
        public Func<OperandType, OperandType> Calculate { get; private set; }
        #endregion
    }
}

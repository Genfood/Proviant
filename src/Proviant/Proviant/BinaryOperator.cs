using System;
namespace Proviant
{
    /// <summary>
    /// Binary operator.
    /// A binary operator needs two operands to be calulated.
    /// </summary>
    public class BinaryOperator<OperandType>: Operator<OperandType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Proviant.BinaryOperator`1"/> class.
        /// </summary>
        /// <param name="calculate">The function to calculate this operator.</param>
        public BinaryOperator(Func<OperandType, OperandType, OperandType> calculate)
        {
            Calculate = calculate;
        }

        #region properties
        /// <summary>
        /// Gets or sets the calculate.
        /// </summary>
        /// <value>The calculate.</value>
        public Func<OperandType, OperandType, OperandType> Calculate { get; set; }
        #endregion
    }
}

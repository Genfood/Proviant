using System;
namespace Proviant
{
    public class BinaryOperator<OperandType>: Operator<OperandType>
    {
        public BinaryOperator(Func<OperandType, OperandType, OperandType> calculate)
        {
            Calculate = calculate;
        }

        #region properties
        public Func<OperandType, OperandType, OperandType> Calculate { get; set; }
        #endregion
    }
}

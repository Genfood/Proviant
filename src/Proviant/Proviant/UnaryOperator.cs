using System;
namespace Proviant
{
    public class UnaryOperator<OperandType> : Operator<OperandType>
    {
        public UnaryOperator(Func<OperandType, OperandType> calculate)
        {
            this.Calculate = calculate;
        }

        #region properties
        public Func<OperandType, OperandType> Calculate { get; private set; }
        #endregion
    }
}

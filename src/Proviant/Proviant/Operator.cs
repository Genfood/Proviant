using System;
using System.Collections.Generic;

namespace Proviant
{
    public abstract class Operator<OperandType> : IOperator
    {
        public Operator()
        {

        }

        #region properties
        public string Name { get; set; }
        public List<string> AlternativeNames { get; set; }
        public int Priority { get; set; }
        #endregion
    }
}

using System.Collections.Generic;

namespace Proviant
{
    public class TruthRow
    {
        public TruthRow()
        {
            Operands = new Dictionary<string, bool>();
        }
        #region properties
        public Dictionary<string, bool> Operands { get; set; }
        public bool EvaluatedResult { get; set; }
        #endregion
    }


}
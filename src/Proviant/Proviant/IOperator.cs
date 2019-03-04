using System.Collections.Generic;

namespace Proviant
{
    public interface IOperator
    {
        string Name { get; set; }
        List<string> AlternativeNames { get; set; }
        int Priority { get; set; }
    }
}
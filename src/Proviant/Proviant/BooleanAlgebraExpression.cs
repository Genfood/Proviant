using System;
using System.Collections.Generic;
using System.Linq;

namespace Proviant
{
    public class BooleanAlgebraExpression : Expression<bool>
    {
        public BooleanAlgebraExpression(string expressionString)
            : base(expressionString)
        {
            #region
            var not = new UnaryOperator<bool>((o) => { return !o; })
            {
                Priority = 5,
                Name = "not",
                AlternativeNames = new List<string> { "NOT", "!", "¬", " ̃" }
            };

            var and = new BinaryOperator<bool>((o1, o2) => { return o1 && o2; })
            {
                Priority = 4,
                Name = "and",
                AlternativeNames = new List<string> { "AND", "&", "&&", "∧", "•" }
            };

            var nand = new BinaryOperator<bool>((o1, o2) => { return !(o1 && o2); })
            {
                Priority = 4,
                Name = "nand",
                AlternativeNames = new List<string> { "NAND", "⊼" }
            };

            var or = new BinaryOperator<bool>((o1, o2) => { return o1 || o2; })
            {
                Priority = 3,
                Name = "or",
                AlternativeNames = new List<string> { "OR", "|", "||", "∨", "+" }
            };

            var nor = new BinaryOperator<bool>((o1, o2) => { return !(o1 || o2); })
            {
                Priority = 3,
                Name = "nor",
                AlternativeNames = new List<string> { "NOR", "⊽" }
            };

            var materialImplecation = new BinaryOperator<bool>((o1, o2) => { return !o1 || o2; })
            {
                Priority = 2,
                Name = "materialImplecation",
                AlternativeNames = new List<string> { "materialimplecation", "→", "⊃", "⇒" }
            };

            var materialEqvivalence = new BinaryOperator<bool>((o1, o2) => { return o1 == o2; })
            {
                Priority = 1,
                Name = "materialEqvivalence",
                AlternativeNames = new List<string> { "materialeqvivalence", "⇔" }
            };

            var bracket = new BinaryOperator<bool>(null)
            {
                Priority = 0,
                Name = "(",
                AlternativeNames = new List<string> { "bracket", "[", "{" }
            };

            Operators.Add(not.Name, not);
            Operators.Add(and.Name, and);
            Operators.Add(nand.Name, nand);
            Operators.Add(or.Name, or);
            Operators.Add(nor.Name, nor);
            Operators.Add(materialImplecation.Name, materialImplecation);
            Operators.Add(materialEqvivalence.Name, materialEqvivalence);
            Operators.Add(bracket.Name, bracket);
            #endregion

        }

        public Dictionary<string, bool> GenerateTruthTable()
        {
            throw new NotImplementedException();
        }

        public override bool Convert(string value) =>  System.Convert.ToBoolean(value);

        public override bool TryParse(string value, out bool result) => bool.TryParse(value, out result);
    }
}

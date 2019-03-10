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

        public TruthTable GenerateTruthTable()
        {
            var table = new TruthTable();

            var variables = new List<KeyValue>();

            NormalizeExpression();
            ToPostfix();
            var postfix = postfixExpression;

            // Search for all variables in the postfix expression.
            foreach (var t in postfix.Split(' '))
            {
                if (alphabet.Contains(t.ToUpper()))
                {
                    if (variables.Find(x => x.Key == t.ToUpper()) == null)
                    {
                        variables.Add(new KeyValue(t.ToUpper()));
                    }
                }
            }

            // order the alphabetically.
            variables = variables.OrderBy(x => x.Key).ToList();

            for (int i = 0; i < Math.Pow(variables.Count, 2); i++)
            {
                // create new row.
                var row = new TruthRow();
                // generate binary string which represents a single row of the truth table.
                string binary = System.Convert.ToString(i, 2).PadLeft(variables.Count(), '0');

                for (int j = 0; j < variables.Count; j++)
                {
                    var b = binary[j];
                    variables[j].Value = b != '0';
                }

                // replace the variable with the current boolean value
                string postfixToEval = postfix;



                var list = postfixToEval.Split(' ');
                for (int j = 0; j < list.Length; j++)
                {
                    foreach (var item in variables)
                    {
                        if (list[j].ToUpper() == item.Key)
                        {
                            list[j] = item.Value.ToString();
                            row.Operands.Add(item.Key, item.Value);
                        }
                    }
                }

                postfixToEval = String.Join(" ", list);

                //postfixToEval = postfixToEval.ToUpper().Replace($" {item.Key} ", $" {item.Value.ToString()} ");


                // evaluate the expression.
                row.EvaluatedResult = evaluatePostfix(postfixToEval);
                table.TruthRows.Add(row);
            }

            return table;
        }

        public override bool Convert(string value) => System.Convert.ToBoolean(value);

        public override bool TryParse(string value, out bool result) => bool.TryParse(value, out result);
    }
}

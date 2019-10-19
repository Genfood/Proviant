using System;
using System.Collections.Generic;
using System.Text;

namespace Proviant
{
    // TODO: alles auf englisch üb
    public class NumberTheoryExpression : Expression<int>
    {
        public NumberTheoryExpression(string exprssionString)
            : base(exprssionString)
        {
            #region Operators
            BinaryOperator<int> mod = new BinaryOperator<int>(modRechnen)
            {
                Name = "mod",
                Priority = 5,
                AlternativeNames = new List<string>
                {
                    "%", "mod"
                }
            };

            BinaryOperator<int> plus = new BinaryOperator<int>((o1, o2) => o1 + o2)
            {
                Name = "plus",
                Priority = 4,
                AlternativeNames = new List<string>
                {
                    "+", "addiere", "plus"
                }
            };

            BinaryOperator<int> minus = new BinaryOperator<int>((o1, o2) => o1 - o2)
            {
                Name = "minus",
                Priority = 4,
                AlternativeNames = new List<string>
                {
                    "-", "minus", "subtrahiere"
                }
            };

            BinaryOperator<int> multiply = new BinaryOperator<int>((o1, o2) => o1 * o2)
            {
                Name = "multiply",
                Priority = 5,
                AlternativeNames = new List<string>
                {
                    "*", "multipliziere", "mal", "x"
                }
            };

            BinaryOperator<int> divide = new BinaryOperator<int>((o1, o2) => (int)o1 / o2)
            {
                Name = "div",
                Priority = 5,
                AlternativeNames = new List<string>
                {
                    "/", "geteilt", "teil"
                }
            };

            var bracket = new BinaryOperator<int>(null)
            {
                Priority = 0,
                Name = "(",
                AlternativeNames = new List<string> { "bracket", "[", "{" }
            };

            Operators.Add(plus.Name, plus);
            Operators.Add(mod.Name, mod);
            Operators.Add(minus.Name, minus);
            Operators.Add(multiply.Name, multiply);
            Operators.Add(divide.Name, divide);
            Operators.Add(bracket.Name, bracket);
            #endregion
        }


        int modRechnen(int o1, int o2)
        {
            return o1 % o2;
        }

        public override int Convert(string value)
        {
            return System.Convert.ToInt32(value);
        }

        public override bool TryParse(string value, out int result)
        {
            return int.TryParse(value, out result);
        }
    }
}

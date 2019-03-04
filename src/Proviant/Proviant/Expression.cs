using System;
using System.Collections.Generic;
using System.Text;

namespace Proviant
{
    public abstract class Expression<T>
        where T:IConvertible
    {
        public Expression(string exprssionString)
        {
            ExpressionString = exprssionString;
            Operators = new Dictionary<string, Operator<T>>();
            DefaultValue = default(T);
        }

        #region properties
        public string ExpressionString { get; set; }

        static string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public Dictionary<string, Operator<T>> Operators { get; set; }
        public T DefaultValue { get; set; }
        #endregion

        public string ToPostfix(string normalizedInfixExpression)
        {
            if (String.IsNullOrWhiteSpace(normalizedInfixExpression))
            {
                return String.Empty;
            }

            Stack<string> opStack = new Stack<string>();


            List<string> postfixList = new List<string>();
            foreach (string token in normalizedInfixExpression.Split(' '))
            {
                if (alphabet.Contains(token.ToUpper()) || bool.TryParse(token, out bool n))
                {
                    postfixList.Add(token);
                }
                else if (token == "(")
                {
                    opStack.Push(token);
                }
                else if (token == ")")
                {
                    string topToken = opStack.Pop();

                    while (topToken != "(")
                    {
                        postfixList.Add(topToken);
                        topToken = opStack.Pop();
                    }
                }
                else
                {
                    while (opStack.Count != 0 && Operators[opStack.Peek()].Priority >= Operators[token].Priority)
                    {
                        postfixList.Add(opStack.Pop());
                    }
                    opStack.Push(token);
                }
            }

            while (opStack.Count != 0)
            {
                postfixList.Add(opStack.Pop());
            }

            return String.Join(" ", postfixList);
        }

        public T EvaluatePostfix(string postfixExpression)
        {
            if (String.IsNullOrWhiteSpace(postfixExpression))
            {
                return DefaultValue;
            }

            Stack<T> operandStack = new Stack<T>();

            foreach (string token in postfixExpression.Split(' '))
            {
                var o = Operators[token];
                if (TryParse(token, out T n))
                {
                    operandStack.Push(Convert(token));
                }
                else if (o.GetType() == typeof(UnaryOperator<T>))
                {
                    T operand1 = operandStack.Pop();
                    T result = ((UnaryOperator<T>)o).Calculate(operand1);

                    operandStack.Push(result);
                }
                else
                {
                    T operand2 = operandStack.Pop();
                    T operand1 = operandStack.Pop();
                    T result = ((BinaryOperator<T>)o).Calculate(operand1, operand2);

                    operandStack.Push(result);
                }
            }
            return operandStack.Pop();
        }

        /// <summary>
        /// Normalizes the expression.
        /// </summary>
        /// <returns>The normalized expression.</returns>
        /// <param name="infixExpression">Expression.</param>
        public string NormalizeExpression(string infixExpression)
        {
            var sb = new StringBuilder(infixExpression);

            foreach (var o in Operators)
            {
                foreach (var name in o.Value.AlternativeNames)
                {
                    sb.Replace(name, o.Value.Name);
                }
            }

            return sb.ToString();
        }

        public abstract bool TryParse(string value, out T result);

        public abstract T Convert(string value);
    }
}

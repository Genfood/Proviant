using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proviant
{
    /// <summary>
    /// Inherit from this class to create an expression evaluator for a specified gramma.
    /// </summary>
    public abstract class Expression<T>
        where T:IConvertible
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Proviant.Expression`1"/> class.
        /// </summary>
        /// <param name="exprssionString">Exprssion string.</param>
        public Expression(string exprssionString)
        {
            ExpressionString = exprssionString;
            Operators = new Dictionary<string, Operator<T>>();
            DefaultValue = default(T);
        }

        #region properties
        /// <summary>
        /// Gets or sets the expression string.
        /// </summary>
        /// <value>The expression string.</value>
        public string ExpressionString { get; set; }

        /// <summary>
        /// Gets or sets the normalized expression.
        /// </summary>
        /// <value>The normalized expression.</value>
        public string NormalizedExpression { get; set; }

        /// <summary>
        /// Gets or sets the postfix expression.
        /// </summary>
        /// <value>The postfix expression.</value>
        public string PostfixExpression { get; set; }

        /// <summary>
        /// The alphabet.
        /// </summary>
        static protected string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// Gets or sets the operators for this expression context.
        /// </summary>
        /// <value>The operators.</value>
        public Dictionary<string, Operator<T>> Operators { get; set; }

        /// <summary>
        /// Gets or sets the default value.
        /// </summary>
        /// <value>The default value.</value>
        public T DefaultValue { get; set; }
        #endregion

        /// <summary>
        /// Converts a string to a postfix expression.
        /// </summary>
        /// <returns>The postfix.</returns>
        public string ToPostfix()
        {
            if (String.IsNullOrWhiteSpace(this.NormalizedExpression))
            {
                return String.Empty;
            }

            Stack<string> opStack = new Stack<string>();

            var ops = Operators.Keys.Union(new string[] { ")", "]", "}" });

            List<string> postfixList = new List<string>();
            foreach (string token in this.NormalizedExpression.Split(' '))
            {
                                            // TODO: remove?
                if (!ops.Contains(token) || bool.TryParse(token, out bool n))
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
                    while (opStack.Count != 0 && Operators[opStack.Peek()].Priority > Operators[token].Priority)
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

            PostfixExpression = String.Join(" ", postfixList);
            return PostfixExpression;
        }

        /// <summary>
        /// Evaluates the postfix expression.
        /// </summary>
        /// <returns>The result.</returns>
        public T EvaluatePostfix()
        {
            return evaluatePostfix(PostfixExpression);
        }

        /// <summary>
        /// Evaluates the postfix expression.
        /// </summary>
        /// <returns>The result.</returns>
        /// <param name="postfixExpression">Postfix expression.</param>
        protected T evaluatePostfix(string postfixExpression)
        {
            if (String.IsNullOrWhiteSpace(postfixExpression))
            {
                return DefaultValue;
            }

            Stack<T> operandStack = new Stack<T>();

            foreach (string token in postfixExpression.Split(' '))
            {
                if (TryParse(token, out T n))
                {
                    operandStack.Push(Convert(token));
                }
                else if (Operators[token].GetType() == typeof(UnaryOperator<T>))
                {
                    T operand1 = operandStack.Pop();
                    T result = ((UnaryOperator<T>)Operators[token]).Calculate(operand1);

                    operandStack.Push(result);
                }
                else
                {
                    T operand2 = operandStack.Pop();
                    T operand1 = operandStack.Pop();
                    T result = ((BinaryOperator<T>)Operators[token]).Calculate(operand1, operand2);

                    operandStack.Push(result);
                }
            }
            return operandStack.Pop();
        }

        /// <summary>
        /// Normalizes the expression.
        /// </summary>
        /// <returns>The normalized expression.</returns>
        public string NormalizeExpression()
        {
            // Split string to list.
            var expressionList = ExpressionString.Split(' ');

            for (int i = 0; i < expressionList.Count(); i++)
            {
                var token = expressionList[i];

                foreach (var o in Operators)
                {
                    if (o.Value.AlternativeNames.Contains(token))
                    {
                        expressionList[i] = o.Key;
                    }
                }
            }
            
            NormalizedExpression = String.Join(" ", expressionList);
            return NormalizedExpression;
        }

        /// <summary>
        /// Evaluate the Expression.
        /// </summary>
        /// <returns>The evaluation result.</returns>
        public T Evaluate()
        {
            NormalizeExpression();
            ToPostfix();
            return EvaluatePostfix();
        }

        /// <summary>
        /// Tries the parse.
        /// </summary>
        /// <returns><c>true</c>, if parse was tryed, <c>false</c> otherwise.</returns>
        /// <param name="value">Value.</param>
        /// <param name="result">Result.</param>
        public abstract bool TryParse(string value, out T result);

        /// <summary>
        /// Convert the specified value.
        /// </summary>
        /// <returns>The convert.</returns>
        /// <param name="value">Value.</param>
        public abstract T Convert(string value);
    }
}

using System;

namespace Proviant.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = Console.ReadLine();
            do
            {
                var expr = new BooleanAlgebraExpression(s);
                //string normalized = expr.NormalizeExpression();
                //string postfix = expr.ToPostfix();
                //Console.WriteLine($"Ergebniss: {expr.Evaluate()}" );

                var table = expr.GenerateTruthTable();

                s = Console.ReadLine();
            } while (!String.IsNullOrWhiteSpace(s));

        }
    }
}

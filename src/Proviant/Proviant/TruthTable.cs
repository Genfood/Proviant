using System;
using System.Collections.Generic;
using System.Linq;

namespace Proviant
{
    /// <summary>
    /// Truth table.
    /// </summary>
    public class TruthTable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Proviant.TruthTable"/> class.
        /// </summary>
        public TruthTable()
        {
            TruthRows = new List<TruthRow>();
        }

        #region properties
        /// <summary>
        /// Gets or sets the truth rows.
        /// </summary>
        /// <value>The truth rows.</value>
        public List<TruthRow> TruthRows { get; set; }

        /// <summary>
        /// The total amount of colums. 
        /// </summary>
        /// <value>Colums count.</value>
        public int Colums
        {
            get
            {
                if (TruthRows.Count > 0)
                {
                    if (TruthRows[0].Operands.Count > 0)
                    {
                        return TruthRows[0].Operands.Count + 1;
                    }
                }

                return 0;
            }
        }

        /// <summary>
        /// The total amount of rows. 
        /// </summary>
        /// <value>Rows count.</value>
        public int Rows
        {
            get
            {
                return TruthRows.Count;
            }
        }
        #endregion

        #region methods
        /// <summary>
        /// Generates the conjunctive normal form.
        /// The disjunction of all disjunctive clauses. Result is false (0).
        /// </summary>
        /// <returns>The conjunctive normal form.</returns>
        public string CNF()
        {
            var konList = TruthRows.Where(x => !x.EvaluatedResult).ToList();
            List<string> maxTerms = new List<string>();

            foreach (var row in konList)
            {
                List<string> literals = new List<string>();

                foreach (var o in row.Operands)
                {
                    if (o.Value)
                    {
                       literals.Add($"¬{o.Key}");
                    }
                    else
                    {
                        literals.Add($"{o.Key}");
                    }
                }
                maxTerms.Add($"({String.Join("∨", literals)})");
            }

            return String.Join("∧", maxTerms);
        }

        /// <summary>
        /// Generates the disjunctive normal form.
        /// The disjunction of all conjunctive clauses. Result is true (1).
        /// </summary>
        /// <returns></returns>
        public string DNF()
        {
            var disList = TruthRows.Where(x => x.EvaluatedResult).ToList();
            List<string> maxTerms = new List<string>();

            foreach (var row in disList)
            {
                List<string> literals = new List<string>();

                foreach (var o in row.Operands)
                {
                    if (!o.Value)
                    {
                        literals.Add($"¬{o.Key}");
                    }
                    else
                    {
                        literals.Add($"{o.Key}");
                    }
                }
                maxTerms.Add($"({String.Join("∧", literals)})");
            }

            return String.Join("∨", maxTerms);
        }
        #endregion
    }
}

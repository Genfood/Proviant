# Proviant [![Build Status](https://travis-ci.com/Genfood/boolean-algebra-shunting-yard.svg?branch=master)](https://travis-ci.com/Genfood/boolean-algebra-shunting-yard) [![Nuget](https://img.shields.io/nuget/v/Proviant.svg)](https://www.nuget.org/packages/Proviant/)
Proviant is a framework which evaluate boolean-expressions under the help of the Shunting-yard algorithm.

## Features
* Calculating boolean-algebra expressio
* Generatin a truth table for a boolean expression
* Create your own expression evaluator for a specific gramma.

## Supported opertaors

| Operatorname | Symbol | Precedence | Is unary |
| --- | --- | --- | --- |
| NOT | ￢ | 5 | true |
| AND | ∧ | 4 | false |
| NAND | ⊼ | 4 | false |
| OR | ∨ | 3 | false |
| NOR | ⊽ | 3 | false |
| Material Implecation | → | 2 | false |
| Material Eqvivalence | ⇔ | 1 | false |

## Usage

### Boolean Algebra

#### Evaluate a common boolean expression

Add `using`:
```csharp
using Proviant;
```
Til now the tokens in an expression string needs to seperated by a whitespace.
Create a new expression:
```csharp
// A boolean expression.
string expressionString = "false or true and ( false ⇔ false )";
// Create a new BooleanAlgebraExpression instance.
var expr = new BooleanAlgebraExpression(expressionString);

// Evaluate expression.
// Result will be true.
bool result = expr.Evaluate();
```

#### Generating a truth-table

```csharp
// A boolean expression.
string expressionString = "A or B and C";
// Create a new BooleanAlgebraExpression instance.
var expr = new BooleanAlgebraExpression(expressionString);

// returns TruthTable class.
var truthTable = expr.GenerateTruthTable();
```

The truth-table would look like:

| A | B | C | Y |
| --- | --- | --- | --- |
| 0 | 0 | 0 | **0** |
| 0 | 0 | 1 | **0** |
| 0 | 1 | 0 | **0** |
| 0 | 1 | 1 | **1** |
| 1 | 0 | 0 | **1** |
| 1 | 0 | 1 | **1** |
| 1 | 1 | 0 | **1** |
| 1 | 1 | 1 | **1** |

1 = True  
0 = False  
**Y** = represents the evaluated result

##### TruthTable class documentation

| Property | Type | Description |
| --- | --- | --- |
| `TruthRows` | [`TruthRows`](#truthrow-class-documentation) | A truth row contains the state of each variable and the calculated result. |
| `Rows` | `int` | The total count of rows in this truth-table. |
| `Colums` | `int`|  The total count of colums in this truth-table. |

##### TruthRow class documentation

| Property | Type | Description |
| --- | --- | --- |
| `Operands` | `Dictionary<string, bool>` | A dictionary of operand and it's current state. The key is the operand. The value represents the state of the operand.  |
| `EvaluatedResult` | `bool` | The evaluated result. |

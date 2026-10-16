using System.Numerics;
using ProjectEuler.Core;
using ProjectEuler.Core.Utilities;

namespace ProjectEuler.Problems;

public sealed class Problem0015: ProblemBase
{
    public override string Title => "Lattice Paths";

  

    public override string Solve()
    {
           
       BigInteger totalCombinations = NumberTheory.Binomial(40,20);
        return totalCombinations.ToString();
    }

    
}



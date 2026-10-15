using System.Security;
using ProjectEuler.Core;

namespace ProjectEuler.Problems;

public sealed class Problem0001 : ProblemBase
{
    public override string Title => "Multiples of 3 or 5";

    public override string Solve()
    //=>        //Enumerable.Range(1, 999).Where(n => n % 3 == 0 || n % 5 == 0).Sum().ToString();
    {
        var sum = 0;
        for (var i = 1; i < 1000; i++){
            if (i % 3 == 0 || i % 5 == 0)
            {
                sum += i;
            }
        }
        return sum.ToString();
    }
}
